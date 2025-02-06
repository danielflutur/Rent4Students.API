using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities.Joined;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class RentHistoryRepository : BaseRepository<RentHistory>, IRentHistoryRepository
    {
        public RentHistoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public override async Task<RentHistory> GetById(Guid id)
        {
            return await _dbSet
                .Where(history => history.Id == id)
                .Include(history => history.Student)
                .Include(history => history.Listing)
                .Include(history => history.AttatchedPhoto)
                .Include(history => history.RentDocument)
                .Include(history => history.RentStatus)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<RentHistory>> GetAll()
        {
            return await _dbSet
                .Where(history => history.IsDeleted == false)
                .Include(history => history.Student)
                .Include(history => history.Listing)
                .Include(history => history.AttatchedPhoto)
                .Include(history => history.RentDocument)
                .Include(history => history.RentStatus)
                .ToListAsync();
        }
    }
}
