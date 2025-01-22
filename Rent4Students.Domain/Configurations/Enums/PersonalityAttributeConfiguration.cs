using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Configurations.Enums
{
    public class PersonalityAttributeConfiguration : BaseEnumEntityConfiguration<PersonalityAttribute>
    {
        public override void Configure(EntityTypeBuilder<PersonalityAttribute> builder)
        {
            base.Configure(builder);

            builder.Property(feature => feature.Value)
                .IsRequired(false);
        }
    }
}
