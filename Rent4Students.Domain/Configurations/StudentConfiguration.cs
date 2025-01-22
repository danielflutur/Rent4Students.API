using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class StudentConfiguration : BaseEntityConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);

            builder.Property(user => user.FirstName)
                .IsRequired();

            builder.Property(user => user.LastName)
                .IsRequired();

            builder.Property(user => user.Email)
                .IsRequired();

            builder.Property(user => user.EncryptedPassword)
                .IsRequired();

            builder.Property(user => user.Phone)
               .IsRequired(false);

            builder.Property(student => student.StudentIdNumber)
                .IsRequired();

            builder.Property(student => student.Age)
                .IsRequired();

            builder.Property(student => student.YearOfStudy)
                .IsRequired(false);

            builder.HasOne(student => student.Gender)
                .WithMany()
                .HasForeignKey(student => student.GenderId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(student => student.Nationality)
                .WithMany()
                .HasForeignKey(student => student.NationalityId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(student => student.FacultyName)
                .WithMany()
                .HasForeignKey(student => student.FacultyId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(student => student.ProfilePhoto)
                .WithOne(photo => photo.Student)
                .HasForeignKey<StoredPhoto>(student => student.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(student => student.Address)
                .WithOne(address => address.Student)
                .HasForeignKey<Address>(address => address.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

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

            builder.HasMany(student => student.Hobbies)
                .WithOne(hobbies => hobbies.Student)
                .HasForeignKey(hobbies => hobbies.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(student => student.Allergies)
                .WithOne(allergies => allergies.Student)
                .HasForeignKey(allergies => allergies.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
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
