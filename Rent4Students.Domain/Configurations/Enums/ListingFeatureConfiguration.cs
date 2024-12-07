using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Configurations.Enums
{
    internal class ListingFeatureConfiguration : BaseEnumEntityConfiguration<ListingFeature>
    {
        public override void Configure(EntityTypeBuilder<ListingFeature> builder)
        {
            base.Configure(builder);

            builder.Property(feature => feature.Value)
                .IsRequired();

            builder.HasMany(feature => feature.OfferedAmenities)
                .WithOne(amenities => amenities.ListingFeature)
                .HasForeignKey(amenities => amenities.ListingFeatureId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasMany(feature => feature.StudentPreferences)
                .WithOne(preferences => preferences.ListingFeature)
                .HasForeignKey(preferences => preferences.ListingFeatureId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
