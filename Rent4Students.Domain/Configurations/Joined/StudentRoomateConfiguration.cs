using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Configurations.Joined
{
    public class StudentRoomateConfiguration : IEntityTypeConfiguration<StudentRoommate>
    {
        public void Configure(EntityTypeBuilder<StudentRoommate> builder)
        {
            builder.HasKey(studentRoommate => new { studentRoommate.StudentId, studentRoommate.RoommateId });

            builder.HasOne(studentRoommate => studentRoommate.Student)
                .WithMany()
                .HasForeignKey(studentRoommate => studentRoommate.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(studentRoommate => studentRoommate.Roommate)
                .WithMany()
                .HasForeignKey(studentRoommate => studentRoommate.RoommateId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
