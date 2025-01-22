using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Entities.Joined
{
    public record StudentAllergies
    {
        public int AllergyId { get; set; }
        public Allergy Allergy { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
