using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Configurations.Joined
{
    public class StudentRoommateConfiguration : IEntityTypeConfiguration<StudentRoommate>
    {
        public void Configure(EntityTypeBuilder<StudentRoommate> builder) 
        {
            builder.HasKey(studentRoommate => new { studentRoommate.StudentId, studentRoommate.RoommateId });

            builder.Property(roommate => roommate.IsActive)
                .IsRequired();

            builder.HasOne(studentRoommate => studentRoommate.Student)
                .WithMany(student => student.Roommates)
                .HasForeignKey(studentRoommate => studentRoommate.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(studentRoommate => studentRoommate.Roommate)
                .WithMany()
                .HasForeignKey(studentRoommate => studentRoommate.RoommateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
