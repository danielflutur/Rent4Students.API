using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class RentDocumentRepository : DocumentStorageRepository, IRentDocumentRepository
    {
        public RentDocumentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
