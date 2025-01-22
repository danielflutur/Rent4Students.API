using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Entities.Joined
{
    public record StudentAttributes
    {
        public int AttributeId {  get; set; }
        public PersonalityAttribute Attribute { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
