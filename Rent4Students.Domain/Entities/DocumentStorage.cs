using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Entities
{
    public record DocumentStorage : BaseEntity
    {
        public string? StorageURL { get; set; }
        public int DocumentStatusId { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType Type { get; set; }
        public Guid ListingId { get; set; }
        public Listing Listing { get; set; }
        public Guid? OwnerID { get; set; }
        public PropertyOwner? Owner { get; set; }
        public Guid? AgencyId { get; set; }
        public Agency? Agency { get; set; }
        public List<Student>? Students { get; set; }
    }
}
