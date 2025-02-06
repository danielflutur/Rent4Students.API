using AutoMapper;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Joined;
using Rent4Students.Infrastructure.Repositories;
using Rent4Students.Infrastructure.Repositories.Interfaces;
using Rent4Students.Infrastructure.Repositories.Interfaces.Enums;

namespace Rent4Students.Application.Services
{
    public class RentDocumentService : IRentDocumentService
    {
        private readonly IRentDocumentRepository _documentRepository;
        private readonly IDocumentStatusRepository _documentStatusRepository;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IListingRepository _listingRepository;
        private readonly IMapper _mapper;

        public RentDocumentService(
            IRentDocumentRepository documentRepository,
            IDocumentStatusRepository statusRepository,
            IDocumentTypeRepository documentTypeRepository,
            IHttpContextAccessor httpContextAccessor,
            IListingRepository listingRepository,
            IMapper mapper)
        {
            _documentRepository = documentRepository;
            _documentStatusRepository = statusRepository;
            _documentTypeRepository = documentTypeRepository;
            _httpContextAccessor = httpContextAccessor;
            _listingRepository = listingRepository;
            _mapper = mapper;
        }

        public async Task<byte[]> GetRentContract(Guid id)
        {
            var doc = await _documentRepository.GetById(id);

            if (doc == null)
                throw new FileNotFoundException("Document not found.");

            if (!File.Exists(doc.DocumentPath))
                throw new FileNotFoundException("File not found on the server.");

            return await File.ReadAllBytesAsync(doc.DocumentPath);
        }

        public async Task<RentDocument> UploadRentContract(IFormFile file, Guid listingId)
        {
            var request = _httpContextAccessor.HttpContext?.Request;

            if (request == null)
                throw new InvalidOperationException("No active HTTP context");

            ValidateFile(file);

            var document = new RentDocument();
            document.Id = Guid.NewGuid();

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "StoredDocs");
            Directory.CreateDirectory(uploadsFolder);

            var listing = await _listingRepository.GetById(listingId);
            var rentHistory = listing.RentHistory.OrderByDescending(history => history.UpdatedAt).FirstOrDefault();

            document.MonthlyRent = listing.RentPrice;
            document.DepositAmount = (int)listing.DepositAmount;
            document.StartDate = DateTime.Today;
            document.EndDate = document.StartDate.AddYears(1);
            document.RentHistories = new List<RentHistory> { rentHistory };
            document.DocumentName = listing.Title + listing.Id + "DocumentANAF" + Path.GetExtension(file.FileName);
            document.DocumentPath = Path.Combine(uploadsFolder, document.DocumentName);

            document.DocumentStatusId = 1;
            document.DocumentStatus = await _documentStatusRepository.GetById(document.DocumentStatusId);

            document.DocumentTypeId = 1;
            document.DocumentType = await _documentTypeRepository.GetById(document.DocumentTypeId);

            using (var stream = new FileStream(document.DocumentPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            document.StorageURL = $"{request.Scheme}://{request.Host}/StoredDocs/{document.DocumentName}";

            return await _documentRepository.Create(document, rentHistory);
        }

        private void ValidateFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("No file uploaded");

            var validTypes = new[] { "application/pdf" };
            if (!validTypes.Contains(file.ContentType))
                throw new ArgumentException("Invalid file type. Accepted types is .pdf");
        }
    }
}
