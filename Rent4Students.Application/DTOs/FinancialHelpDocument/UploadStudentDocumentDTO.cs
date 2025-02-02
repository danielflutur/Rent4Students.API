using Microsoft.AspNetCore.Http;

namespace Rent4Students.Application.DTOs.FinancialHelpDocument
{
    public class UploadStudentDocumentDTO
    {
        public Guid? FacultyId { get; set; }
        public Guid? StudentId { get; set; }
    }
}
