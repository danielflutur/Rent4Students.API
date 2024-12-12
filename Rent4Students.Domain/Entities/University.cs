using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record University : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string EncryptedPassword { get; private set; }
        public string? Phone { get; set; }
        public string CIF { get; set; }
        public string InstitutionalCode { get; set; }
        public bool IsValidated { get; set; }
        
        public Guid? ProfilePictureId { get; private set; }
        public StoredPhoto? ProfilePhoto { get; private set; }
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }

        public List<Faculty> Faculties { get; set; }
    }
}
