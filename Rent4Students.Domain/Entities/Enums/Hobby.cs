using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities.Enums
{
    public record Hobby : BaseEnumEntity
    {
        public List<StudentHobbies> StudentHobbies { get; set; }
    }
}
