using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record Listing : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
