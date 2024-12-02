using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Entities
{
    public record Payment : BaseEntity
    {
        public decimal PaymentAmount { get; set; }
        public int? PaymentPlanId { get; set; }
        public PaymentPlan? PaymentPlan { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int? PaymentStatusId { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
    }
}
