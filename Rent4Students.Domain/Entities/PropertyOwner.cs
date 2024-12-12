using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record PropertyOwner : BaseEntity
    {
        public string? FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string EncryptedPassword { get; private set; }
        public string Phone { get; set; }

        public Guid? ProfilePictureId { get; set; }
        public StoredPhoto? ProfilePhoto { get; set; }
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }

        public List<Listing>? Listings { get; set; }
    }
}
