namespace Rent4Students.Domain.Entities.Joined
{
    public record StudentRoommate
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid RoommateId { get; set; }
        public Student Roommate { get; set; }
    }
}
