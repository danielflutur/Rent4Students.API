using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Configurations.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Configurations.Enums
{
    public class DocumentTypeConfiguration : BaseEnumEntityConfiguration<DocumentType>
    {
        public override void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            base.Configure(builder);

            builder.HasMany(docType => docType.Documents)
                .WithOne(document => document.DocumentType)
                .HasForeignKey(document => document.DocumentTypeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
