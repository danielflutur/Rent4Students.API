using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities
{
    public record Agency : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string Phone { get; set; }
        public string CIF { get; set; }
        public List<Listing> Listings { get; set; }
    }
}
