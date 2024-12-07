using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class ListingConfiguration : BaseEntityConfiguration<Listing>
    {
        public override void Configure(EntityTypeBuilder<Listing> builder)
        {
            base.Configure(builder);

            builder.Property(listing => listing.Title)
                .IsRequired();

            builder.Property(listing => listing.Description)
                .IsRequired();


            builder.Property(listing => listing.Description)
                .IsRequired();

            builder.HasOne(listing => listing.ListingType)
                .WithMany(type => type.Listings)
                .HasForeignKey(listing => listing.ListingTypeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(listing => listing.Address)
                .WithOne(address => address.Listing)
                .HasForeignKey<Address>(address => address.ListingId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(listing => listing.Owner)
                .WithMany(owner => owner.Listings)
                .HasForeignKey(listing => listing.OwnerID)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasMany(listing => listing.Photos)
                .WithOne(photo => photo.ParentListing)
                .HasForeignKey(photo => photo.ListingId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(listing => listing.Amenities)
                .WithOne(livingAmenity => livingAmenity.Listing)
                .HasForeignKey(livingAmenity => livingAmenity.ListingId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasMany(listing => listing.RentHistory)
                .WithOne(document => document.Listing)
                .HasForeignKey(document => document.ListingId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
