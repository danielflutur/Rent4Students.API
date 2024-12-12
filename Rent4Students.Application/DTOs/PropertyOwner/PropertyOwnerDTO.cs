using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Address;

namespace Rent4Students.Application.DTOs.PropertyOwner
{
    public class PropertyOwnerDTO
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string Phone { get; set; }
        public IFormFile ProfilePhoto { get; set; }
        public AddressDTO Address { get; set; }
    }
}
