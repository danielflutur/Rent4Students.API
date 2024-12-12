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

            builder.Property(photo => photo.PhotoPath)
                .IsRequired();

            builder.HasOne(photo => photo.ParentListing)
                .WithMany(listing =>listing.Photos)
                .HasForeignKey(photo => photo.ListingId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasOne(photo => photo.Student)
                .WithOne(student => student.ProfilePhoto)
                .HasForeignKey<Student>(student => student.ProfilePictureId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);


            builder.HasOne(photo => photo.University)
                .WithOne(university => university.ProfilePhoto)
                .HasForeignKey<University>(university => university.ProfilePictureId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);


            builder.HasOne(photo => photo.Faculty)
                .WithOne(faculty => faculty.ProfilePhoto)
                .HasForeignKey<Faculty>(faculty => faculty.ProfilePictureId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);


            builder.HasOne(photo => photo.PropertyOwner)
                .WithOne(owner => owner.ProfilePhoto)
                .HasForeignKey<PropertyOwner>(owner => owner.ProfilePictureId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
