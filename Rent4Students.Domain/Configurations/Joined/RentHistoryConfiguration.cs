using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Configurations.Joined
{
    public class RentHistoryConfiguration : BaseEntityConfiguration<RentHistory>
    {
        public override void Configure(EntityTypeBuilder<RentHistory> builder)
        {
            base.Configure(builder);

            builder.HasOne(history => history.Student)
                .WithMany(student => student.RentHistory)
                .HasForeignKey(history => history.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(history => history.Listing)
                .WithMany(listing => listing.RentHistory)
                .HasForeignKey(history => history.ListingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(history => history.AttatchedPhoto)
                .WithOne(photo => photo.RentHistory)
                .HasForeignKey<StoredPhoto>(photo => photo.RentHistoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(history => history.RentDocument)
                .WithMany(document => document.RentHistories)
                .HasForeignKey(history => history.RentDocumentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasOne(history => history.RentStatus)
                .WithMany()
                .HasForeignKey(history => history.RentStatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
