using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Enums;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities
{
    public record Listing : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int RentPrice { get; set; }  

        public int ListingTypeId { get; set; }
        public ListingType ListingType { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public Guid OwnerID { get; set; }
        public PropertyOwner Owner { get; set; }

        public List<StoredPhoto> Photos { get; set; }
        public List<LivingAmenities> Amenities { get; set; }
        public List<RentHistory>? RentHistory { get; set; }
    }
}
