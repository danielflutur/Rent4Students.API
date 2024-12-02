using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities
{
    public record Student : User
    {
        public string StudentIdNumber { get; private set; } // Nr. Matricol
        public Guid? RentedProperyId { get; set; }
        public Listing? RentedProperty { get; set; }
        public Guid UniversityID { get; private set; }
        public University UniversityName { get; private set; }
        public Guid FacultyId { get; private set; }
        public Faculty FacultyName { get; private set; }
        public Guid? RoommateId { get; private set; }
        public Student? Roommate { get; private set; }
        public Guid DocumentId { get; private set; }
        public DocumentStorage Documents { get; private set; }
        public List<StudentPreferences>? Preferences { get; private set; }
        public List<LivingPreferences>? LivingPreferences { get; private set; }\
    }
}
