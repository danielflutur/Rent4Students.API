using Rent4Students.Domain.Entities.Enums;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces.Enums;

namespace Rent4Students.Infrastructure.Repositories.Enums
{
    public class DocumentStatusRepository : BaseEnumRepository<DocumentStatus>, IDocumentStatusRepository
    {
        public DocumentStatusRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
