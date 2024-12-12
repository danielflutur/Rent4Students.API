using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Enums;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities
{
    public record Student : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string EncryptedPassword { get; private set; }
        public string? Phone { get; set; }
        public string StudentIdNumber { get; private set; } // Nr. Matricol
        public int Age { get; private set; }

        public int NationalityId { get; private set; }
        public Nationality Nationality { get; private set; }

        public Guid FacultyId { get; private set; }
        public Faculty FacultyName { get; private set; }
        public Guid? ProfilePictureId { get; private set; }
        public StoredPhoto? ProfilePhoto { get; private set; }
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }

        public List<FinancialHelpDocument>? FinancialHelpDocuments { get; private set; }
        public List<RentHistory>? RentHistory { get; private set; }
        public List<StudentRoommate>? Roommates { get; private set; }
        public List<StudentAttribute>? Attributes { get; private set; }
        public List<LivingPreference>? LivingPreferences { get; private set; }
    }
}
