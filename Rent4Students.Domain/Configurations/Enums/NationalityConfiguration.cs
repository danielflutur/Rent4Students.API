using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Configurations.Enums
{
    public class NationalityConfiguration : BaseEnumEntityConfiguration<Nationality>
    {
        public override void Configure(EntityTypeBuilder<Nationality> builder)
        {
            base.Configure(builder);
        }
    }
}
