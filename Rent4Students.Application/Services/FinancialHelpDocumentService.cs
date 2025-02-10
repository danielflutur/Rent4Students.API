using AutoMapper;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.FinancialHelpDocument;
using Rent4Students.Application.DTOs.Student;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Repositories.Interfaces;
using Rent4Students.Infrastructure.Repositories.Interfaces.Enums;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Rent4Students.Application.Services
{
    public class FinancialHelpDocumentService : IFinancialHelpDocumentService
    {
        private readonly IFinancialHelpDocumentRepository _documentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor; 
        private readonly IFacultyRepository _facultyRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IDocumentStatusRepository _documentStatusRepository;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IMapper _mapper;

        public FinancialHelpDocumentService(
            IFinancialHelpDocumentRepository documentRepository,
            IHttpContextAccessor httpContextAccessor,
            IFacultyRepository facultyRepository,
            IStudentRepository studentRepository,
            IDocumentStatusRepository documentStatusRepository,
            IDocumentTypeRepository documentTypeRepository,
            IMapper mapper)
        {
            _documentRepository = documentRepository;
            _httpContextAccessor = httpContextAccessor;
            _facultyRepository = facultyRepository;
            _studentRepository = studentRepository;
            _documentStatusRepository = documentStatusRepository;
            _documentTypeRepository = documentTypeRepository;
            _mapper = mapper;
        }


        public async Task Delete(Guid id)
        {
            var document = await _documentRepository.GetById(id);

            if (document is null)
            {
                throw new KeyNotFoundException();
            }

            await _documentRepository.Delete(document);
        }

        public async Task<List<ResponseStudentDocumentDTO>> GetAllDocs()
        {
            return _mapper.Map<List<ResponseStudentDocumentDTO>>(await _documentRepository.GetAll());
        }

        public async Task<List<ResponseFacultyRequestDTO>> GetAllFaculty(Guid id)
        {
            var docs = await _documentRepository.GetAll();
            var filteredDocs = docs.Where(doc => doc.FacultyId == id && doc.DocumentTypeId == 2 );

            var mappedDocs = new List<ResponseFacultyRequestDTO>();
            foreach (var doc in filteredDocs)
            {
                mappedDocs.Add(new ResponseFacultyRequestDTO
                {
                    DocumentDetails = new ResponseStudentDocumentDTO
                    {
                        DocumentName = doc.DocumentName,
                        DocumentStatusId = doc.DocumentStatusId,
                        Id = doc.Id,
                        StorageURL = doc.StorageURL
                    },
                    StudentDetails = new ResponseStudentDetailsDTO
                    {
                        Id = doc.Student.Id,
                        Email = doc.Student.Email,
                        FirstName = doc.Student.FirstName,
                        LastName = doc.Student.LastName,
                    }
                });
            }

            return mappedDocs;
        }

        public async Task<byte[]> GetFacultyTemplate(Guid facultyId, Guid studentId)
        {
            var docs = await _documentRepository.GetAll();
            var student = await _studentRepository.GetById(studentId);
            var templateDoc = docs.FirstOrDefault(doc => doc.FacultyId == facultyId && doc.DocumentType.Name == "FinancialHelpTemplate");

            if (templateDoc == null)
                throw new FileNotFoundException("Template document not found.");

            if (!File.Exists(templateDoc.DocumentPath))
                throw new FileNotFoundException("Template file not found on the server.");

            var filledDocumentPath = Path.Combine(Path.GetDirectoryName(templateDoc.DocumentPath),
                                           $"{student.FirstName}{student.LastName}{templateDoc.Faculty.Name}.pdf");

            using (var pdfReader = new PdfReader(templateDoc.DocumentPath))
            using (var fileStream = new FileStream(filledDocumentPath, FileMode.Create, FileAccess.Write))
            {
                using (var stamper = new PdfStamper(pdfReader, fileStream))
                {
                    var form = stamper.AcroFields;

                    form.SetField("full_name", $"{student.LastName} {student.FirstName}" ?? "");
                    form.SetField("birth_address", $"{student.Address.AddressDetails}, {student.Address.City}, {student.Address.County}" ?? "");
                    form.SetField("study_year", $"{student.YearOfStudy}" ?? "");
                    form.SetField("sign_date", DateTime.UtcNow.ToShortDateString() ?? "");
                    form.SetField("student_full_name", $"{student.LastName} {student.FirstName}" ?? "");
                    form.SetField("student_study_year", $"{student.YearOfStudy}" ?? "");
                    form.SetField("student_signing_date", DateTime.UtcNow.ToShortDateString() ?? "");

                    // Flatten the form to make it read-only (optional)
                    //stamper.FormFlattening = true;
                }
            }

            return await File.ReadAllBytesAsync(filledDocumentPath);
        }

        public async Task<List<ResponseStudentDocumentDTO>> GetAllForStudent(Guid id)
        {
            var docs = await _documentRepository.GetAll();

            return _mapper.Map<List<ResponseStudentDocumentDTO>>(docs.Where(doc => doc.StudentId == id));
        }

        public async Task<byte[]> GetDocument(Guid id)
        {
            var doc = await _documentRepository.GetById(id);

            if (doc == null)
                throw new FileNotFoundException("Document not found.");

            if (!File.Exists(doc.DocumentPath))
                throw new FileNotFoundException("File not found on the server.");

            return await File.ReadAllBytesAsync(doc.DocumentPath);
        }

        public async Task<FinancialHelpDocument> UploadRentDocuments(IFormFile file, Guid studentId)
        {
            var request = _httpContextAccessor.HttpContext?.Request;

            if (request == null)
            {
                throw new InvalidOperationException("No active HTTP context");
            }

            ValidateFile(file);

            var document = new FinancialHelpDocument();
            document.Id = Guid.NewGuid();

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "StoredDocs");
            Directory.CreateDirectory(uploadsFolder);

            var student = await _studentRepository.GetById(studentId);

            document.Student = student;
            document.StudentId = studentId;
            document.Faculty = student.FacultyName;
            document.FacultyId = student.FacultyId;
            document.DocumentName = $"{student.FirstName}{student.LastName}{student.FacultyName.Name}FullDocument.pdf";
            document.DocumentPath = Path.Combine(uploadsFolder, document.DocumentName);

            document.DocumentStatusId = 3;
            document.DocumentStatus = await _documentStatusRepository.GetById(document.DocumentStatusId);

            document.DocumentTypeId = 2;
            document.DocumentType = await _documentTypeRepository.GetById(document.DocumentTypeId);

            using (var stream = new FileStream(document.DocumentPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            document.StorageURL = $"{request.Scheme}://{request.Host}/StoredDocs/{document.DocumentName}";

            return await _documentRepository.Create(document);
        }

        public async Task<FinancialHelpDocument> UploadTemplate(IFormFile file, Guid facultyId)
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
                throw new InvalidOperationException("No active HTTP context");
            ValidateFile(file);

            var document = new FinancialHelpDocument();
            document.Id = Guid.NewGuid();

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "StoredDocs");
            Directory.CreateDirectory(uploadsFolder);

            var faculty = await _facultyRepository.GetById(facultyId);
            
            document.Faculty = faculty;
            document.FacultyId = facultyId;
            document.DocumentName = faculty.Name + "DocumentTemplate" + Path.GetExtension(file.FileName);
            document.DocumentPath = Path.Combine(uploadsFolder, document.DocumentName);

            document.DocumentStatusId = 1;
            document.DocumentStatus = await _documentStatusRepository.GetById(document.DocumentStatusId);

            document.DocumentTypeId = 4;
            document.DocumentType = await _documentTypeRepository.GetById(document.DocumentTypeId);

            using (var stream = new FileStream(document.DocumentPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            document.StorageURL = $"{request.Scheme}://{request.Host}/StoredDocs/{document.DocumentName}";

            return await _documentRepository.Create(document);
        }

        public async Task<FinancialHelpDocument> UpdateRequestStatus(Guid documentId, int documentStatus)
        {
            var document = await _documentRepository.GetById(documentId);
            document.DocumentStatusId = documentStatus;
            document.DocumentStatus = await _documentStatusRepository.GetById(documentStatus);

            return await _documentRepository.Update(document);
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
