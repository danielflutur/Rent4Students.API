using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Entities
{
    public record FinancialHelpDocument : BaseEntity
    {
        public string? StorageURL { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }

        public int DocumentStatusId { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public Guid? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public Guid? StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
