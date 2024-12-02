using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Enums;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities
{
    public record Listing : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ListingTypeId { get; set; }
        public ListingType ListingType { get; set; }
        public Guid? OwnderID { get; set; }
        public User? Owner { get; set; }
        public Guid? ManagingAgencyId { get; set; }
        public Agency? ManagingAgency { get; set; }
        public List<User> Tenants { get; set; }
        public List<StoredPhoto> Photos { get; set; }
        public List<LivingAmenities> Amenities { get; set; }
    }
}
