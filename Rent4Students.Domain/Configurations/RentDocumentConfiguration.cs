using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class RentDocumentConfiguration : BaseEntityConfiguration<RentDocument>
    {
        public override void Configure(EntityTypeBuilder<RentDocument> builder)
        {
            base.Configure(builder);

            builder.Property(document => document.StorageURL)
                .IsRequired(false);

            builder.Property(document => document.DocumentName)
                .IsRequired();

            builder.HasOne(document => document.DocumentStatus)
                .WithMany(status => status.RentDocuments)
                .HasForeignKey(document => document.DocumentStatusId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(document => document.DocumentType)
                .WithMany(type => type.RentDocuments)
                .HasForeignKey(document => document.DocumentTypeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

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
