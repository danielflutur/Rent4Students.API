using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Configurations.Base
{
    public class BaseEnumEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEnumEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Name)
                .IsRequired();
        }
    }
}
