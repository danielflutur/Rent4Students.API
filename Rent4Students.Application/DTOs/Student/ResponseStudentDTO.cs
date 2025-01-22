using Rent4Students.Application.DTOs.Address;
using Rent4Students.Application.DTOs.Allergies;
using Rent4Students.Application.DTOs.Attributes;
using Rent4Students.Application.DTOs.Faculty;
using Rent4Students.Application.DTOs.Gender;
using Rent4Students.Application.DTOs.Hobbies;
using Rent4Students.Application.DTOs.Nationality;

namespace Rent4Students.Application.DTOs.Student
{
    public class ResponseStudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string StudentIdNumber { get; set; } 
        public int Age { get; set; }
        public int? YearOfStudy { get; set; }
        public ResponseGenderDTO Gender { get; set; }
        public ResponseNationalityDTO Nationality { get; set; }
        public ResponseStudentFacultyDTO Faculty { get; set; }
        public string ProfilePhoto { get; set; }
        public ResponseAddressDTO Address { get; set; }
        public List<ResponseHobbiesDTO> HobbiesIds { get; set; }
        public List<ResponseAllergiesDTO> AllergiesIds { get; set; }
        public List<ResponseStudentAttributesDTO> AttributesIds { get; set; }
    }
}
