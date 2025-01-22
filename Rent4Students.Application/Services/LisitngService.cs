using AutoMapper;
using Rent4Students.Application.DTOs.Address;
using Rent4Students.Application.DTOs.Listing;
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
        private readonly IMapper _mapper;

        public LisitngService(
            IListingRepository listingRepository, 
            IAddressRepository addressRepository, 
            IPropertyOwnerRepository ownerRepository,
            IListingTypeRepository listingTypeRepository,
            IListingFeatureRepository listingFeatureRepository,
            IStoredPhotoService storedPhotoService,
            IMapper mapper)
        {
            _listingRepository = listingRepository;
            _addressRepository = addressRepository;
            _ownerRepository = ownerRepository;
            _listingTypeRepository = listingTypeRepository;
            _listingFeatureRepository = listingFeatureRepository;
            _storedPhotoService = storedPhotoService;
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
            return _mapper.Map<List<ResponseListingDTO>>(await _listingRepository.GetAll());
        }

        public async Task<ResponseListingDTO> GetById(Guid Id)
        {
            return _mapper.Map<ResponseListingDTO>(await _listingRepository.GetById(Id));
        }

        public async Task<ResponseListingDTO> Update(ListingDTO listingDTO)
        {
            return _mapper.Map<ResponseListingDTO>(await _listingRepository.Update(_mapper.Map<Listing>(listingDTO)));
        }

        private async Task<Address> AddAddress(AddressDTO addressDTO, Listing listing)
        {
            var mappedAddress = _mapper.Map<Address>(addressDTO);
            mappedAddress.ListingId = listing.Id;
            mappedAddress.Listing = listing;

            return await _addressRepository.Create(mappedAddress);
        }
    }
}
