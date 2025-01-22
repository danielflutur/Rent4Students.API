using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class AddressConfiguration : BaseEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(address => address.AddressDetails)
                .IsRequired();

            builder.Property(address => address.GoogleMaps)
                .IsRequired(false);

            builder.Property(address => address.City)
                .IsRequired();

            builder.Property(address =>address.County)
                .IsRequired();
        }
    }
}
