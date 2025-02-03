using Rent4Students.Application.DTOs.Address;
using Rent4Students.Application.DTOs.Faculty;

namespace Rent4Students.Application.DTOs.University
{
    public class ResponseUniversityDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CIF { get; set; }
        public bool IsValidated { get; set; }

        public string ProfilePhoto { get; set; }
        public ResponseAddressDTO Address { get; set; }
        public List<ResponseFacultyDTO> Faculties { get; set; }
    }
}
