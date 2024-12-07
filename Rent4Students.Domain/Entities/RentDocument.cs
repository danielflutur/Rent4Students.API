using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities
{
    public record RentDocument : DocumentStorage
    {
        public decimal MonthlyRent { get; set; }
        public decimal DepositAmount { get; set; }
        public string AdditionalDetails { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RentPaymentDate { get; set; }

        public List<RentHistory> RentHistories { get; set; }
    }
}
