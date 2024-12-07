namespace Rent4Students.Domain.Entities
{
    public record University : User
    {
        public string CIF { get; set; }
        public string InstitutionalCode { get; set; }
        public bool IsValidated { get; set; }
        public List<Faculty> Faculties { get; set; }
    }
}
