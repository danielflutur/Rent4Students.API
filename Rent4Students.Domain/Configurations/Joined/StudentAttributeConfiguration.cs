using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Configurations.Joined
{
    public class StudentAttributeConfiguration : IEntityTypeConfiguration<StudentAttribute>
    {
        public void Configure(EntityTypeBuilder<StudentAttribute> builder)
        {
            builder.HasKey(studentPreferences => new { studentPreferences.UserFeatureId, studentPreferences.StudentId });

            builder.HasOne(studentPreferences => studentPreferences.UserFeature)
                .WithMany()
                .HasForeignKey(studentPreferences => studentPreferences.UserFeatureId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(studentPreferences => studentPreferences.Student)
                .WithMany(student => student.Attributes)
                .HasForeignKey(studentPreferences => studentPreferences.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
