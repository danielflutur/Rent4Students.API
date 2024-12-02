namespace Rent4Students.Domain.Entities
{
    public record PropertyOwner : User
    {
        public List<Listing> Listings { get; set; }
    }
}
