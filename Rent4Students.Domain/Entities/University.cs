using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Entities
{
    public record University : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string Phone { get; set; }
        public string CIF { get; set; }
        public string InstitutionalCode { get; set; }
        public bool IsValidated { get; set; }
        public int PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int PaymentPlan {  get; set; }
        public PaymentPlan CurrentPaymentPlan {  get; set; }
        public List<Faculty> Faculties { get; set; }
    }
}
