using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities.Enums
{
    public record UserFeature : BaseEnumEntity
    {
        public string Value { get; set; }
        public List<StudentAttributes> RoommatePreferences { get; set; }
    }
}
