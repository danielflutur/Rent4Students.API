using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.FinancialHelpDocument;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IFinancialHelpDocumentService
    {
        Task<FinancialHelpDocument> UploadTemplate(IFormFile file, Guid facultyId);
        Task<FinancialHelpDocument> UploadRentDocuments(IFormFile file, Guid studentId);
        Task<byte[]> GetDocument(Guid id);
        Task<List<ResponseStudentDocumentDTO>> GetAllDocs();
        Task<List<ResponseStudentDocumentDTO>> GetAllForStudent(Guid id);
        Task<List<ResponseFacultyRequestDTO>> GetAllFaculty(Guid id);
        Task<byte[]> GetFacultyTemplate(Guid facultyId, Guid studentId);
        Task Delete(Guid id);
        Task<FinancialHelpDocument> UpdateRequestStatus(Guid documentId, int documentStatus);
    }
}
