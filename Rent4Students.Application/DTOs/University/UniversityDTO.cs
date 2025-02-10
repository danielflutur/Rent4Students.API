using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Address;
using Rent4Students.Application.DTOs.Faculty;

namespace Rent4Students.Application.DTOs.University
{
    public class UniversityDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string? Phone { get; set; }
        public string CIF { get; set; }
        public AddressDTO Address { get; set; }
    }
}
