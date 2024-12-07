using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class AddressConfiguration : BaseEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(address => address.StreetAddress)
                .IsRequired();

            builder.Property(address => address.AppartmentNumber)
                .IsRequired(false);

            builder.Property(address => address.FloorNumber)
                .IsRequired(false);

            builder.Property(address => address.BuildingNumber)
                .IsRequired(false);

            builder.Property(address => address.City)
                .IsRequired();

            builder.Property(address =>address.County)
                .IsRequired();

            builder.Property(address => address.Country)
                .IsRequired();

            builder.Property(address => address.PostalCode)
                .IsRequired();

            builder.HasOne(address => address.User)
                .WithOne(user => user.Address)
                .HasForeignKey<User>(user => user.AddressId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasOne(address => address.Listing)
                .WithOne(listing => listing.Address)
                .HasForeignKey<Listing>(listing => listing.AddressId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}
