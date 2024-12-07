using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class PropertyOwnerConfiguration<TEntity> : UserConfiguration<PropertyOwner> where TEntity : PropertyOwner
    {
        public void Configure(EntityTypeBuilder<PropertyOwner> builder)
        {
            builder.HasMany(owner => owner.Listings)
                .WithOne(listing => listing.Owner)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
