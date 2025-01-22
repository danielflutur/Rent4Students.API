using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Enums;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities
{
    public record Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string? Phone { get; set; }
        public string StudentIdNumber { get; set; } // Nr. Matricol
        public int Age { get; set; }
        public int? YearOfStudy { get; set; }

        public int? GenderId { get; set; }
        public Gender? Gender { get; set; }
        public int? NationalityId { get; set; }
        public Nationality? Nationality { get; set; }

        public Guid FacultyId { get; set; }
        public Faculty FacultyName { get; set; }
        public Guid? ProfilePhotoId { get; set; }
        public StoredPhoto? ProfilePhoto { get; set; }
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }

        public List<FinancialHelpDocument>? FinancialHelpDocuments { get; set; }
        public List<RentHistory>? RentHistory { get; set; }
        public List<StudentRoommate>? Roommates { get; set; }
        public List<StudentHobbies>? Hobbies { get; set; }
        public List<StudentAllergies>? Allergies { get; set; }
        public List<StudentAttributes>? Attributes { get; set; }
        public List<LivingPreference>? LivingPreferences { get; set; }
    }
}
