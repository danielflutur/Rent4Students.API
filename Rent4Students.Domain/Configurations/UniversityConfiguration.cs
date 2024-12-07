using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class UniversityConfiguration : UserConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.Property(university => university.CIF)
                .IsRequired();

            builder.Property(university => university.InstitutionalCode)
                .IsRequired();

            builder.Property(university => university.IsValidated)
                .IsRequired();

            builder.HasMany(university => university.Faculties)
                .WithOne(faculty => faculty.ParentUniversity)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
