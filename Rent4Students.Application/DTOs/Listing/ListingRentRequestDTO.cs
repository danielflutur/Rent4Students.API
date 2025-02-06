using Microsoft.AspNetCore.Http;

namespace Rent4Students.Application.DTOs.Listing
{
    public class ListingRentRequestDTO
    {
        public List<IFormFile> StudentIdPhotos { get; set; }
        public List<Guid> StudentIds { get; set; }
        public Guid ListingId { get; set; }
    }
}
