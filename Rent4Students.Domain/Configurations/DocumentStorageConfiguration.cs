using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities;

namespace Rent4Students.Domain.Configurations
{
    public class DocumentStorageConfiguration<TEntity> : BaseEntityConfiguration<DocumentStorage> where TEntity : DocumentStorage
    {
        public override void Configure(EntityTypeBuilder<DocumentStorage> builder)
        {
            base.Configure(builder);

            builder.Property(document => document.StorageURL)
                .IsRequired(false);

            builder.Property(document => document.DocumentName)
                .IsRequired();

            builder.HasOne(document => document.DocumentStatus)
                .WithMany(status => status.Documents)
                .HasForeignKey(document => document.DocumentStatusId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(document => document.DocumentType)
                .WithMany(type => type.Documents)
                .HasForeignKey(document => document.DocumentTypeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }

}
