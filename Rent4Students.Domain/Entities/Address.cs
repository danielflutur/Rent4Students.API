using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record Address : BaseEntity
    {
        public string StreetAddress { get; set; }
        public string? AppartmentNumber { get; set; }
        public string? FloorNumber { get; set; }
        public string? BuildingNumber { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
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
