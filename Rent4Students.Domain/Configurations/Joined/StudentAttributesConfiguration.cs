using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Configurations.Joined
{
    public class StudentAttributesConfiguration : IEntityTypeConfiguration<StudentAttributes>
    {
        public void Configure(EntityTypeBuilder<StudentAttributes> builder)
        {
            builder.HasKey(studentPreferences => new { studentPreferences.UserFeatureId, studentPreferences.StudentId });

            builder.HasOne(studentPreferences => studentPreferences.UserFeature)
                .WithMany(userFeature => userFeature.RoommatePreferences)
                .HasForeignKey(studentPreferences => studentPreferences.UserFeatureId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(studentPreferences => studentPreferences.Student)
                .WithMany(student => student.Attributes)
                .HasForeignKey(studentPreferences => studentPreferences.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
