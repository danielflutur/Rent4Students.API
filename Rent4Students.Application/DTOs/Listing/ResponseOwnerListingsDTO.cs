using Rent4Students.Application.DTOs.Address;
using Rent4Students.Application.DTOs.RentHistory;

namespace Rent4Students.Application.DTOs.Listing
{
    public class ResponseOwnerListingsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Photo {  get; set; }
        public bool IsRented { get; set; }
        public ResponseAddressDTO Address { get; set; }
        public ResponseRentHistoryDTO? RentRequestDetails { get; set; }
    }
}
