using AutoMapper;
using Microsoft.AspNetCore.Http;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Application.Services
{
    public class StoredPhotoService : IStoredPhotoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStoredPhotoRepository _photoRepository;
        private readonly IMapper _mapper;

        public StoredPhotoService(IHttpContextAccessor httpContextAccessor, IStoredPhotoRepository photoRepository, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _photoRepository = photoRepository;
            _mapper = mapper;
        }

        public async Task<StoredPhoto> Create(IFormFile image)
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
                throw new InvalidOperationException("No active HTTP context");
            ValidatePhoto(image);
            var imageId = Guid.NewGuid();
            var storedPhoto = new StoredPhoto();
            storedPhoto.Id = imageId;
            
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "StoredPhotos");
            Directory.CreateDirectory(uploadsFolder);

            storedPhoto.PhotoName = imageId.ToString() + Path.GetExtension(image.FileName);
            storedPhoto.PhotoPath = Path.Combine(uploadsFolder, storedPhoto.PhotoName);

            using (var stream = new FileStream(storedPhoto.PhotoPath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            storedPhoto.PhotoURL = $"{request.Scheme}://{request.Host}/StoredPhotos/{storedPhoto.PhotoName}";

            return await _photoRepository.Create(storedPhoto);
        }

        public async Task<List<StoredPhoto>> CreateMultiple(List<IFormFile> images)
        {
            var storedPhotos = new List<StoredPhoto>();
            foreach (var image in images)
            {
                storedPhotos.Add(await Create(image));
            }

            return storedPhotos;
        }

        public Task Deleted(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<StoredPhoto> GetByFacultyId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StoredPhoto>> GetByListingId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<StoredPhoto> GetByOwnerId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<StoredPhoto> GetByPhotoId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<StoredPhoto> GetByStudentId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<StoredPhoto> GetByUniversityId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<StoredPhoto> Update(StoredPhoto image)
        {
            throw new NotImplementedException();
        }

        public Task<List<StoredPhoto>> Update(List<StoredPhoto> images)
        {
            throw new NotImplementedException();
        }

        private void ValidatePhoto(IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
                throw new ArgumentException("No file uploaded");

            var validTypes = new[] { "image/jpeg", "image/png" };
            if (!validTypes.Contains(photo.ContentType))
                throw new ArgumentException("Invalid file type. Accepted types are .jpeg and .png");
        }
    }
}
