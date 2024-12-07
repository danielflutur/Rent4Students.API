using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities.Enums
{
    public record Role : BaseEnumEntity
    {
        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
