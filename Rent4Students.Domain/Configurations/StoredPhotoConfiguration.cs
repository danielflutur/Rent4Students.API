using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class StoredPhotoConfiguration : BaseEntityConfiguration<StoredPhoto>
    {
        public override void Configure(EntityTypeBuilder<StoredPhoto> builder)
        {
            base.Configure(builder);

            builder.Property(photo => photo.PhotoURL)
                .IsRequired();

            builder.Property(photo => photo.PhotoName)
                .IsRequired();

            builder.Property(photo => photo.PhotoDescription)
                .IsRequired();

            builder.HasOne(photo => photo.ParentListing)
                .WithMany(listing =>listing.Photos)
                .HasForeignKey(photo => photo.ListingId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasOne(photo => photo.User)
                .WithOne(user => user.ProfilePhoto)
                .HasForeignKey<User>(user => user.ProfilePictureId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
