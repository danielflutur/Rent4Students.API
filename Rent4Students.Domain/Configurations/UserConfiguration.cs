using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Configurations
{
    public class UserConfiguration<TEntity> : BaseEntityConfiguration<User> where TEntity : User
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(user => user.FirstName)
                .IsRequired(false);

            builder.Property(user => user.LastName)
                .IsRequired(false);

            builder.Property(user => user.Email)
                .IsRequired();

            builder.Property(user => user.EncryptedPassword)
                .IsRequired();

            builder.Property(user => user.EncryptedPassword)
               .IsRequired();

            builder.HasOne(user => user.UserRole)
                .WithOne(role => role.User)
                .HasForeignKey<Role>(user => user.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(user => user.ProfilePhoto)
                .WithOne(photo => photo.User)
                .HasForeignKey<StoredPhoto>(user => user.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(user => user.Address)
                .WithOne(address => address.User)
                .HasForeignKey<Address>(address => address.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
