using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities.Enums
{
    public record Allergy : BaseEnumEntity
    {
        public List<StudentAllergies> Allergies { get; set; }
    }
}
