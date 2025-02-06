using Rent4Students.Domain.Entities.Joined;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent4Students.Infrastructure.Repositories.Interfaces
{
    public interface IRentHistoryRepository : IBaseRepository<RentHistory>
    {
    }
}
