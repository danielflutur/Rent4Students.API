using Microsoft.AspNetCore.Http;

namespace Rent4Students.Application.DTOs.FinancialHelpDocument
{
    public class UploadTemplateDTO
    {
        public IFormFile file;
        public Guid FacultyId { get; set; }
    }
}
