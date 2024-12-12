using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Configurations.Enums
{
    public class ListingTypeConfiguration : BaseEnumEntityConfiguration<ListingType>
    {
        public override void Configure(EntityTypeBuilder<ListingType> builder)
        {
            base.Configure(builder);
        }
    }
}
