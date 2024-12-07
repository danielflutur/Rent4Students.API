using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Configurations.Joined
{
    public class RentHistoryConfiguration : IEntityTypeConfiguration<RentHistory>
    {
        public void Configure(EntityTypeBuilder<RentHistory> builder)
        {
            builder.HasKey(history => new { history.StudentId, history.ListingId });

            builder.HasOne(history => history.Student)
                .WithMany(student => student.RentHistory)
                .HasForeignKey(history => history.StudentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(history => history.Listing)
                .WithMany(listing => listing.RentHistory)
                .HasForeignKey(history => history.ListingId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(history => history.RentDocument)
                .WithMany(document => document.RentHistories)
                .HasForeignKey(history => history.RentDocumentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(history => history.RentStatus)
                .WithMany()
                .HasForeignKey(history => history.RentStatusId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
