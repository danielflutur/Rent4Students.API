using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Entities.Joined
{
    public record LivingPreferences
    {
        public int ListingFeatureId { get; set; }
        public ListingFeature ListingFeature { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
