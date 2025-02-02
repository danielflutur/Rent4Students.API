using AutoMapper;
using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Address;
using Rent4Students.Application.DTOs.Student;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Joined;
using Rent4Students.Infrastructure.Repositories.Interfaces;
using Rent4Students.Infrastructure.Repositories.Interfaces.Enums;

namespace Rent4Students.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IStoredPhotoService _photoService;
        private readonly IGenderRepository _genderRepository;
        private readonly INationalityRepository _nationalityRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IAllergyRepository _allergyRepository;
        private readonly IPersonalityAttributeRepository _attributeRepository;
        private readonly IListingFeatureRepository _listingFeatureRepository;
        private readonly IMapper _mapper;

        public StudentService(
            IStudentRepository studentRepository,
            IAddressRepository addressRepository,
            IStoredPhotoService photoService,
            IGenderRepository genderRepository,
            INationalityRepository nationalityRepository,
            IFacultyRepository facultyRepository,
            IHobbyRepository hobbyRepository,
            IAllergyRepository allergyRepository,
            IPersonalityAttributeRepository attributeRepository,
            IListingFeatureRepository listingFeatureRepository,
            IMapper mapper)
        {
            _studentRepository = studentRepository;
            _addressRepository = addressRepository;
            _photoService = photoService;
            _genderRepository = genderRepository;
            _nationalityRepository = nationalityRepository;
            _facultyRepository = facultyRepository;
            _hobbyRepository = hobbyRepository;
            _allergyRepository = allergyRepository;
            _attributeRepository = attributeRepository;
            _listingFeatureRepository = listingFeatureRepository;
            _mapper = mapper;
        }

        public async Task<ResponseStudentDTO> Create(StudentDTO studentDTO)
        {
            if (StudentExists(studentDTO, out Student foundStudent))
            {
                return _mapper.Map<ResponseStudentDTO>(foundStudent);
            }

            var gender = await _genderRepository.GetById(studentDTO.GenderId);
            var nationality = await _nationalityRepository.GetById(studentDTO.NationalityId);
            var faculty = await _facultyRepository.GetById(studentDTO.FacultyId);
            var hobbies = await _hobbyRepository.GetByIds(studentDTO.HobbiesIds);
            var allergies = await _allergyRepository.GetByIds(studentDTO.AllergiesIds);
            var attributes = await _attributeRepository.GetByIds(studentDTO.AttributesIds);
            var livingPreferences = await _listingFeatureRepository.GetByIds(studentDTO.LivingPreferencesIds);

            var mappedStudent = _mapper.Map<Student>(studentDTO);
            mappedStudent.Gender = gender;
            mappedStudent.Nationality = nationality;
            mappedStudent.FacultyName = faculty;

            var student = await _studentRepository.Create(mappedStudent);

            student.Hobbies = hobbies
                .Select(hobby => new StudentHobbies
                {
                    Student = student,
                    StudentId = student.Id,
                    Hobby = hobby,
                    HobbyId = hobby.Id
                })
                .ToList();

            student.Allergies = allergies
                .Select(allergy => new StudentAllergies
                {
                    Student = student,
                    StudentId = student.Id,
                    Allergy = allergy,
                    AllergyId = allergy.Id,
                })
                .ToList();

            student.Attributes = attributes
                .Select(attribute => new StudentAttributes
                {
                    Student = student,
                    StudentId = student.Id,
                    Attribute = attribute,
                    AttributeId = attribute.Id,
                })
                .ToList();

            student.LivingPreferences = livingPreferences
                .Select(preference => new LivingPreference
                {
                    Student = student,
                    StudentId = student.Id,
                    ListingFeature = preference,
                    ListingFeatureId = preference.Id,
                })
                .ToList();

            student.Address = await AddAddress(studentDTO.Address, student);
            student.AddressId = student.Address.Id;

            await _studentRepository.Update(student);

            return _mapper.Map<ResponseStudentDTO>(student);
        }

        public async Task<ResponseStudentDTO> AddProfilePhoto(IFormFile profilePhoto, Guid id)
        {
            var photo = await _photoService.Create(profilePhoto);
            var student = await _studentRepository.GetById(id);
            student.ProfilePhoto = photo;
            student.ProfilePhotoId = photo.Id;
            photo.Student = student;
            photo.StudentId = student.Id;

            await _studentRepository.Update(student);

            return _mapper.Map<ResponseStudentDTO>(student);
        }

        public async Task Delete(Guid id)
        {
            var student = await _studentRepository.GetById(id);

            if (student is null)
            {
                throw new KeyNotFoundException();
            }

            await _studentRepository.Delete(student);
        }

        public async Task<List<ResponseStudentDTO>> GetAll()
        {
            return _mapper.Map<List<ResponseStudentDTO>>(await _studentRepository.GetAll());
        }

        public async Task<ResponseStudentDTO> GetById(Guid id)
        {
            return _mapper.Map<ResponseStudentDTO>(await _studentRepository.GetById(id));
        }

        public async Task<ResponseStudentDTO> Update(Guid id, UpdateStudentDTO studentDTO)
        {
            var hobbies = await _hobbyRepository.GetByIds(studentDTO.HobbiesIds);
            var allergies = await _allergyRepository.GetByIds(studentDTO.AllergiesIds);
            var attributes = await _attributeRepository.GetByIds(studentDTO.AttributesIds);
            var livingPreferences = await _listingFeatureRepository.GetByIds(studentDTO.LivingPreferencesIds);
            var student = await _studentRepository.GetById(id);

            _mapper.Map(studentDTO, student);

            student.Hobbies = hobbies
                .Select(hobby => new StudentHobbies
                {
                    Student = student,
                    StudentId = student.Id,
                    Hobby = hobby,
                    HobbyId = hobby.Id
                })
                .ToList();

            student.Allergies = allergies
                .Select(allergy => new StudentAllergies
                {
                    Student = student,
                    StudentId = student.Id,
                    Allergy = allergy,
                    AllergyId = allergy.Id,
                })
                .ToList();

            student.Attributes = attributes
                .Select(attribute => new StudentAttributes
                {
                    Student = student,
                    StudentId = student.Id,
                    Attribute = attribute,
                    AttributeId = attribute.Id,
                })
                .ToList();

            student.LivingPreferences = livingPreferences
                .Select(preference => new LivingPreference
                {
                    Student = student,
                    StudentId = student.Id,
                    ListingFeature = preference,
                    ListingFeatureId = preference.Id,
                })
                .ToList();

            student.Address = await UpdateAddress(studentDTO.Address, student);

            await _studentRepository.Update(student);

            return _mapper.Map<ResponseStudentDTO>(student);
        }


        public async Task<ResponseStudentDTO> UpdateStudentDetails(Guid id, StudentDetailsDTO studentDTO)
        {
            var student = await _studentRepository.GetById(id);
            var hobbies = await _hobbyRepository.GetByIds(studentDTO.HobbiesIds);
            var allergies = await _allergyRepository.GetByIds(studentDTO.AllergiesIds);
            var attributes = await _attributeRepository.GetByIds(studentDTO.AttributesIds);

            await _studentRepository.UpdateStudentDetails(student, hobbies, attributes, allergies);
            
            return _mapper.Map<ResponseStudentDTO>(student);
        }

        private async Task<Address> AddAddress(AddressDTO addressDTO, Student student)
        {
            var mappedAddress = _mapper.Map<Address>(addressDTO);
            mappedAddress.StudentId = student.Id;
            mappedAddress.Student = student;

            return await _addressRepository.Create(mappedAddress);
        }

        private async Task<Address> UpdateAddress(AddressDTO addressDTO, Student student)
        {
            var mappedAddress = _mapper.Map<Address>(addressDTO);
            mappedAddress.StudentId = student.Id;
            mappedAddress.Student = student;

            return await _addressRepository.Update(mappedAddress);
        }

        private bool StudentExists(StudentDTO studentDTO, out Student student)
        {
            var students = _studentRepository.GetAll().Result;
            student = students.FirstOrDefault(student => student.Email.ToLower() == studentDTO.Email.ToLower());
            
            return student != null;
        }
    }
}
