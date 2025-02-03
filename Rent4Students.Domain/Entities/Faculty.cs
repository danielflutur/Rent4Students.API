using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record Faculty : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string Phone { get; set; }
        public string SecretaryName { get; set; }
        public bool EmailSent { get; set; }

        public Guid UniversityId { get; set; }
        public University ParentUniversity { get; set; }
        public Guid? ProfilePhotoId { get; set; }
        public StoredPhoto? ProfilePhoto { get; set; }
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }

        public List<Student>? Students { get; set; }
        public List<FinancialHelpDocument>? FinancialHelpDocuments { get; set; }
    }
}
