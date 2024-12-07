using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Entities
{
    public record User : BaseEntity
    {
        public string? FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string EncryptedPassword { get; private set; }
        public string? Phone { get; set; }

        public int UserRoleId { get; private set; }
        public Role UserRole { get; private set; }
        public Guid? ProfilePictureId { get; private set; }
        public StoredPhoto? ProfilePhoto { get; private set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
