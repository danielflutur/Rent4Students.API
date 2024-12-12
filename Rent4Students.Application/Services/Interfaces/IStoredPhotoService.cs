using Microsoft.AspNetCore.Http;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IStoredPhotoService
    {
        Task<StoredPhoto> Create(IFormFile image);
        Task<List<StoredPhoto>> CreateMultiple(List<IFormFile> images);
        Task<StoredPhoto> GetByPhotoId(Guid Id);
        Task<List<StoredPhoto>> GetByListingId(Guid Id);
        Task<StoredPhoto> GetByStudentId(Guid Id);
        Task<StoredPhoto> GetByUniversityId(Guid Id);
        Task<StoredPhoto> GetByFacultyId(Guid Id);
        Task<StoredPhoto> GetByOwnerId(Guid Id);
        Task<StoredPhoto> Update(StoredPhoto image);
        Task<List<StoredPhoto>> Update(List<StoredPhoto> images);
        Task Deleted(Guid Id);
    }
}
