using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record Faculty : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string EncryptedPassword { get; private set; }
        public string Phone { get; set; }

        public Guid UniversityId { get; set; }
        public University ParentUniversity { get; set; }
        public Guid? ProfilePictureId { get; private set; }
        public StoredPhoto? ProfilePhoto { get; private set; }
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }

        public List<Student>? Students { get; set; }
        public List<FinancialHelpDocument>? FinancialHelpDocuments { get; set; }
    }
}
