using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class AgencyRepository : PropertyOwnerRepository, IAgencyRepository
    {
        public AgencyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
