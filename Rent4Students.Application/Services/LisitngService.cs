using AutoMapper;
using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Address;
using Rent4Students.Application.DTOs.Listing;
using Rent4Students.Application.DTOs.RentHistory;
using Rent4Students.Application.DTOs.Student;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Joined;
using Rent4Students.Infrastructure.Repositories.Interfaces;
using Rent4Students.Infrastructure.Repositories.Interfaces.Enums;

namespace Rent4Students.Application.Services
{
    public class LisitngService : IListingService
    {
        private readonly IListingRepository _listingRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IPropertyOwnerRepository _ownerRepository;
        private readonly IListingTypeRepository _listingTypeRepository;
        private readonly IListingFeatureRepository _listingFeatureRepository;
        private readonly IStoredPhotoService _storedPhotoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRentDocumentService _documentService;
        private readonly IStudentRepository _studentRepository;
        private readonly IRentStatusRepository _rentStatusRepository;
        private readonly IRentHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public LisitngService(
            IListingRepository listingRepository, 
            IAddressRepository addressRepository, 
            IPropertyOwnerRepository ownerRepository,
            IListingTypeRepository listingTypeRepository,
            IListingFeatureRepository listingFeatureRepository,
            IStoredPhotoService storedPhotoService,
            IHttpContextAccessor httpContextAccessor,
            IRentDocumentService documentService,
            IStudentRepository studentRepository,
            IRentStatusRepository leaveStatusRepository,
            IRentHistoryRepository historyRepository,
            IMapper mapper)
        {
            _listingRepository = listingRepository;
            _addressRepository = addressRepository;
            _ownerRepository = ownerRepository;
            _listingTypeRepository = listingTypeRepository;
            _listingFeatureRepository = listingFeatureRepository;
            _storedPhotoService = storedPhotoService;
            _httpContextAccessor = httpContextAccessor;
            _documentService = documentService;
            _studentRepository = studentRepository;
            _rentStatusRepository = leaveStatusRepository;
            _historyRepository = historyRepository;
            _mapper = mapper;
        }

        public async Task<ResponseListingDTO> Create(ListingDTO listingDTO)
        {
            var photos = await _storedPhotoService.CreateMultiple(listingDTO.Photos); 
            listingDTO.Photos = null;
            var owner = await _ownerRepository.GetById(listingDTO.OwnerId);
            var listingType = await _listingTypeRepository.GetById(listingDTO.ListingTypeId);
            var listingFeatures = await _listingFeatureRepository.GetByIds(listingDTO.AmenitiesIds);

            var mappedListing = _mapper.Map<Listing>(listingDTO);
            mappedListing.ListingType = listingType;
            mappedListing.Owner = owner;
            mappedListing.Photos = photos;

            var listing = await _listingRepository.Create(mappedListing);

            listing.Amenities = listingFeatures
                .Select(feature => new LivingAmenity
                {
                    ListingFeature = feature,
                    ListingFeatureId = feature.Id,
                    Listing = listing,
                    ListingId = listing.Id
                })
                .ToList();
            
            listing.Address = await AddAddress(listingDTO.Address, listing);
            listing.AddressId = listing.Address.Id;
            
            await _listingRepository.Update(listing);

            foreach (var photo in photos)
            {
                photo.ParentListing = listing;
                photo.ListingId = listing.Id;
            }

            return _mapper.Map<ResponseListingDTO>(listing);
        }

        public async Task Delete(Guid Id)
        {
            var lisitng = await _listingRepository.GetById(Id);

            if (lisitng is null)
            {
                throw new KeyNotFoundException();
            }

            await _listingRepository.Delete(lisitng);
        }

        public async Task<List<ResponseListingDTO>> GetAll()
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
                throw new InvalidOperationException("No active HTTP context");

            var listings = await _listingRepository.GetAllNotRented();
            var mappedListings = new List<ResponseListingDTO>();

            foreach (var item in listings)
            {
                foreach (var photo in item.Photos)
                {
                    photo.PhotoURL = $"{request.Scheme}://{request.Host}/StoredPhotos/{photo.PhotoName}";
                }

                mappedListings.Add(_mapper.Map<ResponseListingDTO>(item));
            }

            return mappedListings;
        }

        public async Task<List<ResponseOwnerListingsDTO>> GetAllOwnedBy(Guid ownerId)
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
                throw new InvalidOperationException("No active HTTP context");

            var listings = await _listingRepository.GetAll();
            var filteredListings = listings.Where(listing => listing.OwnerID == ownerId);
            var mappedListings = new List<ResponseOwnerListingsDTO>();

            foreach (var item in filteredListings)
            {
                var firstPhoto = item.Photos.FirstOrDefault();
                mappedListings.Add(new ResponseOwnerListingsDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Photo = $"{request.Scheme}://{request.Host}/StoredPhotos/{firstPhoto.PhotoName}",
                    IsRented = CheckIfRented(item),
                    Address = _mapper.Map<ResponseAddressDTO>(item.Address),
                    RentRequestDetails = await GetRentRequestDetails(item)
                });
            }

            return mappedListings;
        }

        public async Task<ResponseListingDTO> GetById(Guid Id)
        {
            return _mapper.Map<ResponseListingDTO>(await _listingRepository.GetById(Id));
        }

        public async Task<ResponseListingDTO> Update(ListingDTO listingDTO)
        {
            return _mapper.Map<ResponseListingDTO>(await _listingRepository.Update(_mapper.Map<Listing>(listingDTO)));
        }

        public async Task<ResponseListingDTO> CreateRentRequest(ListingRentRequestDTO rentRequestDTO)
        {
            var listing = await _listingRepository.GetById(rentRequestDTO.ListingId);
            var photos = await _storedPhotoService.CreateMultiple(rentRequestDTO.StudentIdPhotos);

            for (int i = 0; i < rentRequestDTO.StudentIds.Count; i++)
            {
                var history = await _historyRepository.Create(new RentHistory
                {
                    Id = Guid.NewGuid(),
                    StudentId = rentRequestDTO.StudentIds[i],
                    Student = await _studentRepository.GetById(rentRequestDTO.StudentIds[i]),
                    ListingId = rentRequestDTO.ListingId,
                    Listing = listing,
                    AttatchedPhoto = photos[i],
                    AttatchedPhotoId = photos[i].Id,
                    RentStatusId = 3,
                    RentStatus = await _rentStatusRepository.GetById(3)
                });

                listing.RentHistory.Add(history);
            }

            await _listingRepository.Update(listing);

            return _mapper.Map<ResponseListingDTO>(listing);
        }

        public async Task AcceptRentRequest(AcceptRentHistoryDTO acceptRentDTO)
        {
            var rentHistory = await _historyRepository.GetById(acceptRentDTO.Id);
            var listing = await _listingRepository.GetById(rentHistory.ListingId);
            rentHistory.RentStatusId = 1;
            rentHistory.RentStatus = await _rentStatusRepository.GetById(1);
            var doc = await _documentService.UploadRentContract(acceptRentDTO.RentContract, rentHistory.ListingId);
            rentHistory.RentDocument = doc;
            rentHistory.RentDocumentId = doc.Id;
            listing.IsRented = true;

            await _historyRepository.Update(rentHistory);
        }

        public async Task RejectRentRequest(Guid id)
        {
            var rentHistory = await _historyRepository.GetById(id);

            rentHistory.RentStatusId = 4;
            rentHistory.RentStatus = await _rentStatusRepository.GetById(4);
            
            await _historyRepository.Update(rentHistory);
        }

        private async Task<Address> AddAddress(AddressDTO addressDTO, Listing listing)
        {
            var mappedAddress = _mapper.Map<Address>(addressDTO);
            mappedAddress.ListingId = listing.Id;
            mappedAddress.Listing = listing;

            return await _addressRepository.Create(mappedAddress);
        }

        private bool CheckIfRented(Listing listing)
        {
            return listing.RentHistory.Any(history => history.RentStatusId == 1);
        }

        private async Task<ResponseRentHistoryDTO> GetRentRequestDetails(Listing listing)
        {
            var latestRentHistory = listing.RentHistory.OrderByDescending(listing => listing.UpdatedAt).FirstOrDefault();

            if (latestRentHistory != null)
            {
                return new ResponseRentHistoryDTO
                {
                    Id = latestRentHistory.Id,
                    RentStatusId = latestRentHistory.RentStatusId,
                    StudentRequests = GetStudentsDetails(latestRentHistory),
                    RentContract = await GetRentContract(latestRentHistory),
                };
            }
            else
            {
                return new ResponseRentHistoryDTO();
            }
        }

        private List<ResponseStudentRentRequestDTO> GetStudentsDetails(RentHistory rentHistory)
        {
            var currentStudents = new List<Student>
            {
                rentHistory.Student
            };

            if (rentHistory.Student.Roommates != null)
            {
                foreach (var roommate in rentHistory.Student.Roommates)
                {
                    if (roommate != null && roommate.IsActive == true)
                    {
                        currentStudents.Add(roommate.Roommate);
                    }
                }
            }

            var studentDetails = new List<ResponseStudentRentRequestDTO>();

            foreach (var student in currentStudents)
            {
                studentDetails.Add(new ResponseStudentRentRequestDTO
                {
                    Id = student.Id,
                    Name = $"{student.FirstName} {student.LastName}",
                    StudentIdPhoto = GetIdPhoto(student),
                });
            }

            return studentDetails;
        }

        private string GetIdPhoto(Student student)
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
                throw new InvalidOperationException("No active HTTP context");

            var latestHistory = student.RentHistory.OrderByDescending(history => history.UpdatedAt).FirstOrDefault();
            
            return $"{request.Scheme}://{request.Host}/StoredPhotos/{latestHistory.AttatchedPhoto.PhotoName}";
        }

        private async Task<byte[]> GetRentContract(RentHistory rentHistory)
        {
            if (rentHistory.RentDocumentId == null)
            {
                return default;
            }

            return await _documentService.GetRentContract((Guid)rentHistory.RentDocumentId);
        }
    }
}
