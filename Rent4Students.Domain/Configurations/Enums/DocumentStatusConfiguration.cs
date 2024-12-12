using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Configurations.Enums
{
    public class DocumentStatusConfiguration : BaseEnumEntityConfiguration<DocumentStatus>
    {
        public override void Configure(EntityTypeBuilder<DocumentStatus> builder)
        {
            base.Configure(builder);
        }
    }
}
