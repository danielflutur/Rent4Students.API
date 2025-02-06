using Rent4Students.Application.DTOs.Student;

namespace Rent4Students.Application.DTOs.RentHistory
{
    public class ResponseRentHistoryDTO
    {
        public Guid Id { get; set; }
        public int RentStatusId { get; set; }
        public List<ResponseStudentRentRequestDTO> StudentRequests { get; set; }
        public byte[]? RentContract {  get; set; }
    }
}
