using Rent4Students.Application.DTOs.University;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IUniversityService
    {
        Task<ResponseUniversityDTO> Create(UniversityDTO universityDTO);
        Task<ResponseUniversityDTO> GetById(Guid id);
        Task<List<ResponseUniversityDTO>> GetAll();
        Task<ResponseUniversityDTO> Update(UniversityDTO universityDTO);
        Task Delete(Guid id);
    }
}
