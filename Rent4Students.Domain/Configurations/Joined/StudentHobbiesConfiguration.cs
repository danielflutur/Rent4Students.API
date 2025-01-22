using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Configurations.Joined
{
    public class StudentHobbiesConfiguration : IEntityTypeConfiguration<StudentHobbies>
    {
        public void Configure(EntityTypeBuilder<StudentHobbies> builder)
        {
            builder.HasKey(studentHobbies => new { studentHobbies.StudentId, studentHobbies.HobbyId });

            builder.HasOne(studentHobbies => studentHobbies.Student)
                .WithMany(student => student.Hobbies)
                .HasForeignKey(studentHobbies => studentHobbies.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(studentHobbies => studentHobbies.Hobby)
                .WithMany(hobby => hobby.StudentHobbies)
                .HasForeignKey(studentHobbies => studentHobbies.HobbyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
