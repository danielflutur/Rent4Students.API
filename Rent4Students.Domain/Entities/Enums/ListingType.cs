using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities.Enums
{
    public record ListingType : BaseEnumEntity
    {
        public List<Listing> Listings { get; set; }
    }
}
