using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record StoredPhoto : BaseEntity
    {
        public string PhotoURL { get; set; }
        public string PhotoName { get; set; }
        public string PhotoPath { get; set; }

        public Guid? ListingId { get; set; }
        public Listing? ParentListing { get; set; }
        public Guid? StudentId { get; set; }
        public Student? Student { get; set; }
        public Guid? UniversityId { get; set; }
        public University? University { get; set; }
        public Guid? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public Guid? PropertyOwnerId { get; set; }
        public PropertyOwner? PropertyOwner { get; set; }
    }
}
