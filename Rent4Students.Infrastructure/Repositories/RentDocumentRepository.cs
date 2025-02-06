using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Joined;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class RentDocumentRepository : BaseRepository<RentDocument>, IRentDocumentRepository
    {
        public RentDocumentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<RentDocument> GetById(Guid id)
        {
            return await _dbSet
                .Where(document => document.Id == id)
                .Include(document => document.DocumentStatus)
                .Include(document => document.DocumentType)
                .Include(document => document.RentHistories)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<RentDocument>> GetAll()
        {
            return await _dbSet
                .Where(document => document.IsDeleted == false)
                .Include(document => document.DocumentStatus)
                .Include(document => document.DocumentType)
                .Include(document => document.RentHistories)
                .ToListAsync();
        }

        public async Task<RentDocument> Create(RentDocument entity, RentHistory history)
        {
            history.RentDocumentId = entity.Id;
            history.RentStatusId = 1;

            _context.RentHistory.Update(history);
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
