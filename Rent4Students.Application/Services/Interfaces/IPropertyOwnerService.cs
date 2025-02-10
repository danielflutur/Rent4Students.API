using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.PropertyOwner;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IPropertyOwnerService
    {
        Task<ResponsePropertyOwnerDTO> Create(PropertyOwnerDTO ownerDTO);
        Task<ResponsePropertyOwnerDTO> GetById(Guid Id);
        Task<List<ResponsePropertyOwnerDTO>> GetAll();
        Task<ResponsePropertyOwnerDTO> Update(PropertyOwnerDTO ownerDTO);
        Task Deleted(Guid Id);
        Task<ResponsePropertyOwnerDTO> AddProfilePhoto(IFormFile profilePhoto, Guid id);
    }
}
