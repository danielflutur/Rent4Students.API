using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Student;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IStudentService
    {
        Task<ResponseStudentDTO> Create(StudentDTO studentDTO);
        Task<ResponseStudentDTO> AddRoommate(AddRoommateDTO roommateDTO);
        Task<ResponseStudentDTO> AddProfilePhoto(IFormFile profilePhoto, Guid id);
        Task<ResponseStudentDTO> GetById(Guid id);
        Task<List<ResponseStudentDTO>> GetAll();
        Task<ResponseStudentDTO> Update(Guid id, UpdateStudentDTO studentDTO);
        Task<ResponseStudentDTO> UpdateStudentDetails(Guid id, StudentDetailsDTO studentDTO);
        Task Delete(Guid id);
    }
}
