using Microsoft.AspNetCore.Http;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IRentDocumentService
    {
        Task<RentDocument> UploadRentContract(IFormFile file, Guid listingId);
        Task<byte[]> GetRentContract(Guid id);
    }
}
