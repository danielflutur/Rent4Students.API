using Rent4Students.Application.DTOs;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IPropertyOwnerRepository _propertyOwnerRepository;

        public AuthService(
            IStudentRepository studentRepository, 
            IUniversityRepository universityRepository, 
            IFacultyRepository facultyRepository, 
            IPropertyOwnerRepository propertyOwnerRepository)
        {
            _studentRepository = studentRepository;
            _universityRepository = universityRepository;
            _facultyRepository = facultyRepository;
            _propertyOwnerRepository = propertyOwnerRepository;
        }

        public async Task<ResponseUserDTO> LoginByEmail(string email)
        {
            var student = await _studentRepository.GetByEmail(email);

            if (student != null)
            {
                return new ResponseUserDTO { Id = student.Id, Role = "Student" };
            }

            var university = await _universityRepository.GetByEmail(email);

            if(university != null)
            {
                return new ResponseUserDTO { Id = university.Id, Role = "University" };
            }

            var faculty = await _facultyRepository.GetByEmail(email);

            if (faculty != null)
            {
                return new ResponseUserDTO { Id = faculty.Id, Role = "Faculty" };
            }

            var owner = await _propertyOwnerRepository.GetByEmail(email);

            if (owner != null)
            {
                return new ResponseUserDTO { Id = owner.Id, Role = "PropertyOwner" };
            }

            return default;
        }
    }
}
