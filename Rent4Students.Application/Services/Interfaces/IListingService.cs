using Rent4Students.Application.DTOs.Listing;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IListingService
    {
        Task<ResponseListingDTO> Create(ListingDTO listingDTO);
        Task<ResponseListingDTO> GetById(Guid Id);
        Task<List<ResponseListingDTO>> GetAll();
        Task<ResponseListingDTO> Update(ListingDTO listingDTO);
        Task Delete(Guid Id);
    }
}
