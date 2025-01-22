using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Student;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IStudentService
    {
        Task<ResponseStudentDTO> Create(StudentDTO studentDTO, IFormFile profilePhoto);
        Task<ResponseStudentDTO> GetById(Guid id);
        Task<List<ResponseStudentDTO>> GetAll();
        Task<ResponseStudentDTO> Update(Guid id, UpdateStudentDTO studentDTO);
        Task Delete(Guid id);
    }
}
