using Rent4Students.Application.DTOs.Address;

namespace Rent4Students.Application.DTOs.Student
{
    public class UpdateStudentDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Age { get; set; }
        public int? YearOfStudy { get; set; }
        public AddressDTO? Address { get; set; }
        public List<int>? HobbiesIds { get; set; }
        public List<int>? AllergiesIds { get; set; }
        public List<int>? AttributesIds { get; set; }
        public List<int>? LivingPreferencesIds { get; set; }
    }
}
