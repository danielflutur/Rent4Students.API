using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Configurations.Enums
{
    public class ListingFeatureConfiguration : BaseEnumEntityConfiguration<ListingFeature>
    {
        public override void Configure(EntityTypeBuilder<ListingFeature> builder)
        {
            base.Configure(builder);

            builder.Property(feature => feature.Value)
                .IsRequired();
        }
    }
}
