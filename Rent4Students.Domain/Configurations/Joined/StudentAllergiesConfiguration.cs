using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Configurations.Joined
{
    public class StudentAllergiesConfiguration : IEntityTypeConfiguration<StudentAllergies>
    {
        public void Configure(EntityTypeBuilder<StudentAllergies> builder)
        {
            builder.HasKey(studentAllergies => new { studentAllergies.AllergyId, studentAllergies.StudentId });

            builder.HasOne(studentAllergies => studentAllergies.Student)
                .WithMany(student => student.Allergies)
                .HasForeignKey(studentAllergies => studentAllergies.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(studentAllergies => studentAllergies.Allergy)
                .WithMany(allergy => allergy.Allergies)
                .HasForeignKey(studentAllergies => studentAllergies.AllergyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
