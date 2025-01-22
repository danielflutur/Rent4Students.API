using Rent4Students.Application.DTOs.Address;

namespace Rent4Students.Application.DTOs.Faculty
{
    public class ResponseFacultyDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProfilePhoto { get; set; }
        public ResponseAddressDTO Address { get; set; }
    }
}
