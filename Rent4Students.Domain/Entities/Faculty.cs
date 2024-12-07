namespace Rent4Students.Domain.Entities
{
    public record Faculty : User
    {
        public Guid UniversityId { get; set; }
        public University ParentUniversity { get; set; }

        public List<Student>? Students { get; set; }
        public List<FinancialHelpDocuments>? FinancialHelpDocuments { get; set; }
    }
}
