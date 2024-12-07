using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class FinancialHelpDocumentsConfiguration : DocumentStorageConfiguration<FinancialHelpDocuments>
    {
        public void Configure(EntityTypeBuilder<FinancialHelpDocuments> builder)
        {
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
