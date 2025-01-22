using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record University : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string? Phone { get; set; }
        public string CIF { get; set; }
        public string InstitutionalCode { get; set; }
        public bool IsValidated { get; set; }
        
        public Guid? ProfilePhotoId { get; set; }
        public StoredPhoto? ProfilePhoto { get; set; }
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }

        public List<Faculty>? Faculties { get; set; }
    }
}
