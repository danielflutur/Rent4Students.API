using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class DocumentStorageRepository : BaseRepository<DocumentStorage>, IDocumentStorageRepository
    {
        public DocumentStorageRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
