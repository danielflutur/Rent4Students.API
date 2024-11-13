using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record Faculty : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EncryptedPassword { get; set; }
        public Guid UniversityId { get; set; }
        public University ParentUniversity { get; set; }
    }
}
