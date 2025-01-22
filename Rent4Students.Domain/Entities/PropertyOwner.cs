using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record PropertyOwner : BaseEntity
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string Phone { get; set; }

        public Guid? ProfilePictureId { get; set; }
        public StoredPhoto? ProfilePhoto { get; set; }
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }

        public List<Listing>? Listings { get; set; }
    }
}
