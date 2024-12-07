using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Configurations.Joined
{
    public class LivingAmenitiesConfiguration : IEntityTypeConfiguration<LivingAmenities>
    {
        public void Configure(EntityTypeBuilder<LivingAmenities> builder)
        {
            builder.HasKey(livingAmenities => new { livingAmenities.ListingId, livingAmenities.ListingFeatureId });

            builder.HasOne(livingAmenities => livingAmenities.Listing)
                .WithMany(listing => listing.Amenities)
                .HasForeignKey(livingAmenities => livingAmenities.ListingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(livingAmenities => livingAmenities.ListingFeature)
                .WithMany(listingFeature => listingFeature.OfferedAmenities)
                .HasForeignKey(livingAmenities => livingAmenities.ListingFeatureId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
