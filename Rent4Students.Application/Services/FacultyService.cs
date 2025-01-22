using AutoMapper;
using Rent4Students.Application.DTOs.Faculty;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Application.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IStoredPhotoService _photoService;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public FacultyService(
            IUniversityRepository universityRepository,
            IFacultyRepository facultyRepository,
            IStoredPhotoService photoService,
            IAddressRepository addressRepository,
            IMapper mapper)
        {
            _universityRepository = universityRepository;
            _facultyRepository = facultyRepository;
            _photoService = photoService;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<ResponseFacultyDTO> Create(FacultyDTO facultyDTO)
        {
            var photo = await _photoService.Create(facultyDTO.ProfilePhoto);
            facultyDTO.ProfilePhoto = null;

            var mappedFaculty = _mapper.Map<Faculty>(facultyDTO);
            mappedFaculty.ProfilePhoto = photo;
            mappedFaculty.ProfilePhotoId = photo.Id;
            var university = await _universityRepository.GetById(facultyDTO.UniversityId);
            mappedFaculty.ParentUniversity = university;
            mappedFaculty.UniversityId = mappedFaculty.ParentUniversity.Id;

            var faculty = await _facultyRepository.Create(mappedFaculty);

            var mappedAddress = _mapper.Map<Address>(facultyDTO.Address);
            mappedAddress.FacultyId = faculty.Id;
            mappedAddress.Faculty = faculty;

            faculty.Address = await _addressRepository.Create(mappedAddress);
            faculty.AddressId = faculty.Address.Id;

            university.Faculties?.Add(faculty);

            await _facultyRepository.Update(faculty);

            photo.Faculty = faculty;
            photo.FacultyId = faculty.Id;

            return _mapper.Map<ResponseFacultyDTO>(faculty);
        }

        public async Task Delete(Guid id)
        {
            var faculty = await _facultyRepository.GetById(id);

            if (faculty is null)
            {
                throw new KeyNotFoundException();
            }

            await _facultyRepository.Delete(faculty);
        }

        public async Task<List<ResponseFacultyDTO>> GetAll()
        {
            return _mapper.Map<List<ResponseFacultyDTO>>(await _facultyRepository.GetAll());
        }

        public async Task<ResponseFacultyDTO> GetById(Guid id)
        {
            return _mapper.Map<ResponseFacultyDTO>(await _facultyRepository.GetById(id));
        }

        public async Task<ResponseFacultyDTO> Update(FacultyDTO facultyDTO)
        {
            return _mapper.Map<ResponseFacultyDTO>(await _facultyRepository.Update(_mapper.Map<Faculty>(facultyDTO)));
        }
    }
}
