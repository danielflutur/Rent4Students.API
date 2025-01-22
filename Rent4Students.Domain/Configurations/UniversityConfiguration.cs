using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class UniversityConfiguration : BaseEntityConfiguration<University>
    {
        public override void Configure(EntityTypeBuilder<University> builder)
        {
            builder.Property(user => user.Name)
                .IsRequired();

            builder.Property(user => user.Email)
                .IsRequired();

            builder.Property(user => user.EncryptedPassword)
                .IsRequired();

            builder.Property(user => user.Phone)
               .IsRequired(false);

            builder.Property(university => university.CIF)
                .IsRequired();

            builder.Property(university => university.InstitutionalCode)
                .IsRequired();

            builder.Property(university => university.IsValidated)
                .IsRequired();

            builder.HasOne(university => university.ProfilePhoto)
                .WithOne(photo => photo.University)
                .HasForeignKey<StoredPhoto>(photo => photo.UniversityId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(university => university.Address)
                .WithOne(address => address.University)
                .HasForeignKey<Address>(address => address.UniversityId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(university => university.Faculties)
                .WithOne(faculty => faculty.ParentUniversity)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false)
                ;
        }
    }
}
