using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record User : BaseEntity
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string Email { get; private set; }
        public string EncryptedPassword { get; private set; }
        public string? ProfilePictureURL { get; private set; }
        public Guid? UniversityID { get; private set; }
        public University? UniversityName { get; private set; }

    }
}
