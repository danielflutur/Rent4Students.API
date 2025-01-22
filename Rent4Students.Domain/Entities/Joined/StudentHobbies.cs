using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Entities.Joined
{
    public record StudentHobbies
    {
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
