namespace Rent4Students.Domain.Entities
{
    public record Agency : PropertyOwner
    {
        public string CIF { get; set; }
    }
}
