using Rent4Students.Application.DTOs.Student;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IRoommateMatchingService
    {
        Task<List<ResponseRoommateScoreDTO>> GetAllMatchingStudents(Guid id); 
    }
}
