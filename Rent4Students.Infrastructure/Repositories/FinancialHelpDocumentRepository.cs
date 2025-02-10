using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class FinancialHelpDocumentRepository : BaseRepository<FinancialHelpDocument>, IFinancialHelpDocumentRepository
    {
        public FinancialHelpDocumentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<FinancialHelpDocument> GetById(Guid id)
        {
            return await _dbSet
                .Where(document => document.Id == id)
                .Include(document => document.DocumentStatus)
                .Include(document => document.DocumentType)
                .Include(document => document.Faculty)
                .Include(document => document.Student)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<FinancialHelpDocument>> GetAll()
        {
            return await _dbSet
                .Where(document => document.IsDeleted == false)
                .Include(document => document.DocumentStatus)
                .Include(document => document.DocumentType)
                .Include(document => document.Faculty)
                .Include(document => document.Student)
                .ToListAsync();
        }
    }
}
