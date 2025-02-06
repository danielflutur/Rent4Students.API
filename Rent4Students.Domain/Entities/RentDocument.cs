using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Enums;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities
{
    public record RentDocument : BaseEntity
    {
        public string? StorageURL { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }

        public int DocumentStatusId { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }

        public decimal MonthlyRent { get; set; }
        public decimal DepositAmount { get; set; }
        public string? AdditionalDetails { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<RentHistory> RentHistories { get; set; }
    }
}
