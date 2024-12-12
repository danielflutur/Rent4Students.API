using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class FinancialHelpDocumentRepository : DocumentStorageRepository, IFinancialHelpDocumentRepository
    {
        public FinancialHelpDocumentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
