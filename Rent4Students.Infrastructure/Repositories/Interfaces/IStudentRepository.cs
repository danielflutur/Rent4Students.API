using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Enums;
using Rent4Students.Infrastructure.Repositories.Interfaces.Base;

namespace Rent4Students.Infrastructure.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<Student> UpdateStudentDetails(Student entity, List<Hobby> hobbies, List<PersonalityAttribute> attributes, List<Allergy> allergies);
        Task<Student> GetByEmail(string email);
    }
}
