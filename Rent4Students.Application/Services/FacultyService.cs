using AutoMapper;
using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Faculty;
using Rent4Students.Application.DTOs.Student;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Repositories;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Application.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IStoredPhotoService _photoService;
        private readonly IAddressRepository _addressRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public FacultyService(
            IUniversityRepository universityRepository,
            IFacultyRepository facultyRepository,
            IStoredPhotoService photoService,
            IAddressRepository addressRepository,
            IEmailService emailService,
            IMapper mapper)
        {
            _universityRepository = universityRepository;
            _facultyRepository = facultyRepository;
            _photoService = photoService;
            _addressRepository = addressRepository;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<ResponseFacultyDTO> Create(FacultyDTO facultyDTO)
        {
            var mappedFaculty = _mapper.Map<Faculty>(facultyDTO);
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

            return _mapper.Map<ResponseFacultyDTO>(faculty);
        }

        public async Task<ResponseStudentDTO> AddProfilePhoto(IFormFile profilePhoto, Guid id)
        {
            var photo = await _photoService.Create(profilePhoto);
            var faculty = await _facultyRepository.GetById(id);
            faculty.ProfilePhoto = photo;
            faculty.ProfilePhotoId = photo.Id;
            photo.Faculty = faculty;
            photo.FacultyId = faculty.Id;

            await _facultyRepository.Update(faculty);

            return _mapper.Map<ResponseStudentDTO>(faculty);
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

        public async Task<List<ResponseFacultyDTO>> GetAllByUniversityId(Guid id)
        {
            var faculties = await _facultyRepository.GetAll();
            var filteredFaculties = faculties.Where(faculty => faculty.UniversityId == id);

            return _mapper.Map<List<ResponseFacultyDTO>>(filteredFaculties);
        }

        public async Task<ResponseFacultyDTO> SendFacultyEmail(Guid facultyId)
        {
            var faculty = await _facultyRepository.GetById(facultyId);
            var isEmailSent = await _emailService.SendAccessEmailForFaculty(faculty);
            faculty.EmailSent = isEmailSent;
            await _facultyRepository.Update(faculty);

            return _mapper.Map<ResponseFacultyDTO>(faculty);
        }

        public async Task<ResponseFacultyDTO> GetById(Guid id)
        {
            return _mapper.Map<ResponseFacultyDTO>(await _facultyRepository.GetById(id));
        }

        public async Task<ResponseFacultyDTO> Update(Guid id, UpdateFacultyDTO facultyDTO)
        {
            var faculty = await _facultyRepository.GetById(id);
            _mapper.Map(facultyDTO, faculty);

            return _mapper.Map<ResponseFacultyDTO>(await _facultyRepository.Update(faculty));
        }
    }
}
