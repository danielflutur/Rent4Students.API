using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Entities.Joined
{
    public record LivingAmenity
    {
        public Guid ListingId { get; set; }
        public Listing Listing {  get; set; }
        public int ListingFeatureId { get; set; }
        public ListingFeature ListingFeature { get; set; }
    }
}
