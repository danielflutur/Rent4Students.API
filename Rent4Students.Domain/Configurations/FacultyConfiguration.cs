using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class FacultyConfiguration : BaseEntityConfiguration<Faculty>
    {
        public override void Configure(EntityTypeBuilder<Faculty> builder)
        {
            base.Configure(builder);

            builder.Property(faculty => faculty.Name)
                .IsRequired(false);

            builder.Property(faculty => faculty.Email)
                .IsRequired();

            builder.Property(faculty => faculty.EncryptedPassword)
                .IsRequired();

            builder.Property(faculty => faculty.Phone)
               .IsRequired();

            builder.HasOne(faculty => faculty.ProfilePhoto)
                .WithOne(photo => photo.Faculty)
                .HasForeignKey<StoredPhoto>(photo => photo.FacultyId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(faculty => faculty.Address)
                .WithOne(address => address.Faculty)
                .HasForeignKey<Address>(address => address.FacultyId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(faculty => faculty.ParentUniversity)
                .WithMany(university => university.Faculties)
                .HasForeignKey(faculty => faculty.UniversityId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasMany(faculty => faculty.Students)
                .WithOne(student => student.FacultyName)
                .HasForeignKey(student => student.FacultyId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasMany(faculty => faculty.FinancialHelpDocuments)
                .WithOne(document => document.Faculty)
                .HasForeignKey(document => document.FacultyId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
