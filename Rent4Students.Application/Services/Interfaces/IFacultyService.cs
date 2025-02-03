using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Faculty;
using Rent4Students.Application.DTOs.Student;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<ResponseFacultyDTO> Create(FacultyDTO facultyDTO);
        Task<ResponseFacultyDTO> GetById(Guid id);
        Task<List<ResponseFacultyDTO>> GetAll();
        Task<List<ResponseFacultyDTO>> GetAllByUniversityId(Guid Id);
        Task<ResponseFacultyDTO> SendFacultyEmail(Guid facultyId);
        Task<ResponseFacultyDTO> Update(Guid id, UpdateFacultyDTO facultyDTO);
        Task<ResponseStudentDTO> AddProfilePhoto(IFormFile profilePhoto, Guid id);
        Task Delete(Guid id);
    }
}
