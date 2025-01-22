using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Configurations.Base;

namespace Rent4Students.Domain.Configurations
{
    public class FinancialHelpDocumentConfiguration : BaseEntityConfiguration<FinancialHelpDocument>
    {
        public void Configure(EntityTypeBuilder<FinancialHelpDocument> builder)
        {
            base.Configure(builder);

            builder.Property(document => document.StorageURL)
                .IsRequired(false);

            builder.Property(document => document.DocumentName)
                .IsRequired();

            builder.HasOne(document => document.DocumentStatus)
                .WithMany(status => status.FinancialHelpDocuments)
                .HasForeignKey(document => document.DocumentStatusId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(document => document.DocumentType)
                .WithMany(type => type.FinancialHelpDocuments)
                .HasForeignKey(document => document.DocumentTypeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(document => document.Faculty)
                .WithMany(faculty => faculty.FinancialHelpDocuments)
                .HasForeignKey(document => document.FacultyId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasOne(document => document.Student)
                .WithMany(student => student.FinancialHelpDocuments)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
