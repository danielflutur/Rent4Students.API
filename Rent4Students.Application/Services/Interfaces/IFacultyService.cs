using Rent4Students.Application.DTOs.Faculty;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<ResponseFacultyDTO> Create(FacultyDTO facultyDTO);
        Task<ResponseFacultyDTO> GetById(Guid id);
        Task<List<ResponseFacultyDTO>> GetAll();
        Task<ResponseFacultyDTO> Update(FacultyDTO facultyDTO);
        Task Delete(Guid id);
    }
}
