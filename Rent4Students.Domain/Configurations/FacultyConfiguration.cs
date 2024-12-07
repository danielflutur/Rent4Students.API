using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class FacultyConfiguration : UserConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {

            builder.HasOne(faculty => faculty.ParentUniversity)
                .WithMany(university => university.Faculties)
                .HasForeignKey(faculty => faculty.UniversityId)
                .IsRequired();

            builder.HasMany(faculty => faculty.Students)
                .WithOne(student => student.FacultyName)
                .HasForeignKey(student => student.FacultyId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasMany(faculty => faculty.FinancialHelpDocuments)
                .WithOne(document => document.Faculty)
                .HasForeignKey(document => document.FacultyId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}
