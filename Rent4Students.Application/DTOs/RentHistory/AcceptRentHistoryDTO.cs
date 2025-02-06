using Microsoft.AspNetCore.Http;

namespace Rent4Students.Application.DTOs.RentHistory
{
    public class AcceptRentHistoryDTO
    {
        public Guid Id { get; set; }
        public IFormFile RentContract { get; set; }
    }
}
