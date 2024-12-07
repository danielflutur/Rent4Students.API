using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Configurations.Enums
{
    public class RoleConfiguration : BaseEnumEntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            builder.HasOne(role => role.User)
                .WithOne(user => user.UserRole)
                .HasForeignKey<User>(user => user.UserRoleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
