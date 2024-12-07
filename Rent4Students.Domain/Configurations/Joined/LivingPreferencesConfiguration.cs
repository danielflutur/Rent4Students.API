using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Configurations.Joined
{
    public class LivingPreferencesConfiguration : IEntityTypeConfiguration<LivingPreferences>
    {
        public void Configure(EntityTypeBuilder<LivingPreferences> builder)
        {
            builder.HasKey(livingPreferences => new { livingPreferences.ListingFeatureId, livingPreferences.StudentId });

            builder.HasOne(livingPreferences => livingPreferences.ListingFeature)
                .WithMany(listingFeature => listingFeature.StudentPreferences)
                .HasForeignKey(livingPreferences => livingPreferences.ListingFeatureId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(livingPreferences => livingPreferences.Student)
                .WithMany(student => student.LivingPreferences)
                .HasForeignKey(livingPreferences => livingPreferences.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
