using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Joined;
using Rent4Students.Infrastructure.Repositories.Interfaces.Base;

namespace Rent4Students.Infrastructure.Repositories.Interfaces
{
    public interface IRentDocumentRepository : IBaseRepository<RentDocument>
    {
        Task<RentDocument> Create(RentDocument entity, RentHistory history);
    }
}
