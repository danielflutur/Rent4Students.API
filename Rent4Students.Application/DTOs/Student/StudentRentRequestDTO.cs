using Microsoft.AspNetCore.Http;

namespace Rent4Students.Application.DTOs.Student
{
    public class StudentRentRequestDTO
    {
        public Guid Id { get; set; }
        public IFormFile StudentIdPhoto { get; set; }
    }
}
