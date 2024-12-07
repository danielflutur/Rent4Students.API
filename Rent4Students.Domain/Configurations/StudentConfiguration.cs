using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class StudentConfiguration : UserConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(student => student.StudentIdNumber)
                .IsRequired();

            builder.HasOne(student => student.FacultyName)
                .WithMany()
                .HasForeignKey(student => student.FacultyId)
                .IsRequired();

            builder.HasMany(student => student.FinancialHelpDocuments)
                .WithOne(document => document.Student)
                .HasForeignKey(document => document.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(student => student.RentHistory)
                .WithOne(history => history.Student)
                .HasForeignKey(history => history.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(student => student.Roommates)
                .WithOne(roommate => roommate.Student)
                .HasForeignKey(roommate => roommate.StudentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasMany(student => student.Attributes)
                .WithOne(attributes => attributes.Student)
                .HasForeignKey(attributes => attributes.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(student => student.LivingPreferences)
                .WithOne(preferences => preferences.Student)
                .HasForeignKey(preferences => preferences.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
