using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Configurations.Enums
{
    public class RentStatusConfiguration : BaseEnumEntityConfiguration<RentStatus>
    {
        public override void Configure(EntityTypeBuilder<RentStatus> builder)
        {
            base.Configure(builder);
        }
    }
}
