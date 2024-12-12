using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class PropertyOwnerConfiguration : BaseEntityConfiguration<PropertyOwner>
    {
        public override void Configure(EntityTypeBuilder<PropertyOwner> builder)
        {
            base.Configure(builder);

            builder.Property(owner => owner.FirstName)
                .IsRequired(false);

            builder.Property(owner => owner.LastName)
                .IsRequired();

            builder.Property(owner => owner.Email)
                .IsRequired();

            builder.Property(owner => owner.EncryptedPassword)
                .IsRequired();

            builder.Property(owner => owner.Phone)
               .IsRequired();

            builder.HasOne(owner => owner.ProfilePhoto)
                .WithOne(photo => photo.PropertyOwner)
                .HasForeignKey<StoredPhoto>(photo => photo.PropertyOwnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(owner => owner.Address)
                .WithOne(address => address.PropertyOwner)
                .HasForeignKey<Address>(address => address.PropertyOwnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(owner => owner.Listings)
                .WithOne(listing => listing.Owner)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
