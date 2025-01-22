using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Configurations.Joined
{
    public class StudentAttributesConfiguration : IEntityTypeConfiguration<StudentAttributes>
    {
        public void Configure(EntityTypeBuilder<StudentAttributes> builder)
        {
            builder.HasKey(studentAttribute => new { studentAttribute.StudentId, studentAttribute.AttributeId });

            builder.HasOne(studentAttribute => studentAttribute.Student)
                .WithMany(student => student.Attributes)
                .HasForeignKey(studentAttribute => studentAttribute.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(studentAttribute => studentAttribute.Attribute)
                .WithMany(attribute => attribute.Attributes)
                .HasForeignKey(studentAttribute => studentAttribute.AttributeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
