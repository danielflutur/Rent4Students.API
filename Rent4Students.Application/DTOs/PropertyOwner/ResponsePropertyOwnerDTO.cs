using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Address;

namespace Rent4Students.Application.DTOs.PropertyOwner
{
    public class ResponsePropertyOwnerDTO
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProfilePhoto { get; set; }
        public ResponseAddressDTO Address { get; set; }
    }
}
