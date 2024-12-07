using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class RentDocumentConfiguration : DocumentStorageConfiguration<RentDocument>
    {
        public void Configure(EntityTypeBuilder<RentDocument> builder)
        {
            builder.Property(details => details.MonthlyRent)
                .IsRequired();

            builder.Property(details => details.DepositAmount)
                .IsRequired();

            builder.Property(details => details.AdditionalDetails)
                .IsRequired();

            builder.Property(details => details.StartDate)
                .IsRequired();

            builder.Property(details => details.EndDate)
                .IsRequired();

            builder.Property(details => details.RentPaymentDate)
                .IsRequired();

            builder.HasMany(document => document.RentHistories)
                .WithOne(history => history.RentDocument)
                .HasForeignKey(history => history.RentDocumentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
