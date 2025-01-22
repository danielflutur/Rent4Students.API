using AutoMapper;
using Rent4Students.Application.DTOs.Faculty;
using Rent4Students.Application.DTOs.University;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Application.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IFacultyRepository _faultyRepository;
        private readonly IStoredPhotoService _photoService;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public UniversityService(
            IUniversityRepository universityRepository,
            IFacultyRepository facultyRepository,
            IStoredPhotoService photoService,
            IAddressRepository addressRepository,
            IMapper mapper)
        {
            _universityRepository = universityRepository;
            _faultyRepository = facultyRepository;
            _photoService = photoService;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<ResponseUniversityDTO> Create(UniversityDTO universityDTO)
        {
            var photo = await _photoService.Create(universityDTO.ProfilePhoto);
            universityDTO.ProfilePhoto = null;
            
            var mappedUniversity = _mapper.Map<University>(universityDTO);
            mappedUniversity.ProfilePhoto = photo;
            mappedUniversity.ProfilePhotoId = photo.Id;

            var university = await _universityRepository.Create(mappedUniversity);

            var mappedAddress = _mapper.Map<Address>(universityDTO.Address);
            mappedAddress.UniversityId = university.Id;
            mappedAddress.University = university;

            university.Address = await _addressRepository.Create(mappedAddress);
            university.AddressId = university.Address.Id;

            await _universityRepository.Update(university);

            photo.University = university;
            photo.UniversityId = university.Id;

            return _mapper.Map<ResponseUniversityDTO>(university);
        }

        public async Task Delete(Guid id)
        {
            var university = await _universityRepository.GetById(id);

            if (university is null)
            {
                throw new KeyNotFoundException();
            }

            await _universityRepository.Delete(university);
        }

        public async Task<List<ResponseUniversityDTO>> GetAll()
        {
            return _mapper.Map<List<ResponseUniversityDTO>>(await _universityRepository.GetAll());
        }

        public async Task<ResponseUniversityDTO> GetById(Guid id)
        {
            return _mapper.Map<ResponseUniversityDTO>(await _universityRepository.GetById(id));
        }

        public async Task<ResponseUniversityDTO> Update(UniversityDTO universityDTO)
        {
            return _mapper.Map<ResponseUniversityDTO>(await _universityRepository.Update(_mapper.Map<University>(universityDTO)));
        }
    }
}
