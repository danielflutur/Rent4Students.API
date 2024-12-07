using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record StoredPhoto : BaseEntity
    {
        public string PhotoURL { get; set; }
        public string PhotoName { get; set; }
        public string PhotoDescription { get; set; }

        public Guid? ListingId { get; set; }
        public Listing? ParentListing { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
