using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Address;

namespace Rent4Students.Application.DTOs.Faculty
{
    public class FacultyDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string Phone { get; set; }
        public IFormFile ProfilePhoto { get; set; }
        public AddressDTO Address { get; set; }
        public Guid UniversityId { get; set; }
    }
}
