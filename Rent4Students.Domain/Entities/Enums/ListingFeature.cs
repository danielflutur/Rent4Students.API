using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities.Enums
{
    public record ListingFeature : BaseEnumEntity
    {
        public string Value { get; set; }
        public List<LivingAmenity> OfferedAmenities { get; set; }
        public List<LivingPreference> StudentPreferences { get; set; }
    }
}
