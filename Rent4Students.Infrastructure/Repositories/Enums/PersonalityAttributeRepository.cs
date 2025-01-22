using Rent4Students.Domain.Entities.Enums;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces.Enums;

namespace Rent4Students.Infrastructure.Repositories.Enums
{
    public class PersonalityAttributeRepository : BaseEnumRepository<PersonalityAttribute>, IPersonalityAttributeRepository
    {
        public PersonalityAttributeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
