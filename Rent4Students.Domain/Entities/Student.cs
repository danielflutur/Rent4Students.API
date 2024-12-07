using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Domain.Entities
{
    public record Student : User
    {
        public string StudentIdNumber { get; private set; } // Nr. Matricol

        public Guid FacultyId { get; private set; }
        public Faculty FacultyName { get; private set; }

        public List<FinancialHelpDocuments>? FinancialHelpDocuments { get; private set; }
        public List<RentHistory>? RentHistory { get; private set; }
        public List<StudentRoommate>? Roommates { get; private set; }
        public List<StudentAttributes>? Attributes { get; private set; }
        public List<LivingPreferences>? LivingPreferences { get; private set; }
    }
}
