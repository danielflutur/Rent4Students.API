using Rent4Students.Application.DTOs.Listing;
using Rent4Students.Application.DTOs.RentHistory;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IListingService
    {
        Task<ResponseListingDTO> Create(ListingDTO listingDTO);
        Task<ResponseListingDTO> CreateRentRequest(ListingRentRequestDTO rentRequestDTO);
        Task<ResponseListingDTO> GetById(Guid Id);
        Task<List<ResponseListingDTO>> GetAll();
        Task<List<ResponseOwnerListingsDTO>> GetAllOwnedBy(Guid ownerId);
        Task AcceptRentRequest(AcceptRentHistoryDTO acceptRentDTO);
        Task RejectRentRequest(Guid requestId);
        Task<ResponseListingDTO> Update(ListingDTO listingDTO);
        Task Delete(Guid Id);
    }
}
