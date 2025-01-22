using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record Address : BaseEntity
    {
        public string AddressDetails { get; set; }
        public string? GoogleMaps {  get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public Guid? StudentId { get; set; }
        public Student? Student { get; set; }
        public Guid? UniversityId { get; set; }
        public University? University { get; set; }
        public Guid? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public Guid? PropertyOwnerId { get; set; }
        public PropertyOwner? PropertyOwner { get; set; }
        public Guid? ListingId { get; set; }
        public Listing? Listing { get; set; }
    }
}
