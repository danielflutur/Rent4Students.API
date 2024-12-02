using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record RentDocumentDetails : BaseEntity
    {
        public decimal MonthlyRent { get; set; }
        public decimal DepositAmount { get; set; }
        public string DepositReturnTerms { get; set; }
        public string RenewalTerms { get; set; }
        public string TerminationClause { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? RentPaymentDate { get; set; }
        public Guid PaymentDetailId { get; set; }
        public Payment PaymentDetails { get; set; }
    }
}
