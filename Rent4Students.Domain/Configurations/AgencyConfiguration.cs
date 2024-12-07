using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class AgencyConfiguration : PropertyOwnerConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.Property(agency => agency.CIF)
                .IsRequired();
        }
    }
}
