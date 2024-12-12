using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Configurations.Enums
{
    public class UserFeatureConfiguration : BaseEnumEntityConfiguration<UserFeature>
    {
        public override void Configure(EntityTypeBuilder<UserFeature> builder)
        {
            base.Configure(builder);

            builder.Property(feature => feature.Value)
                .IsRequired(false);
        }
    }
}
