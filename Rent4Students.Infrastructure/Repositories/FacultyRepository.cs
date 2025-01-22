using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class FacultyRepository : BaseRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<Faculty> GetById(Guid id)
        {
            return await _dbSet
                .Where(faculty => faculty.Id == id)
                .Include(faculty => faculty.ParentUniversity)
                .Include(faculty => faculty.ProfilePhoto)
                .Include(faculty => faculty.Address)
                .Include(faculty => faculty.Students)
                .Include(faculty => faculty.FinancialHelpDocuments)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<Faculty>> GetAll()
        {
            return await _dbSet
                .Where(faculty => faculty.IsDeleted == false)
                .Include(faculty => faculty.ParentUniversity)
                .Include(faculty => faculty.ProfilePhoto)
                .Include(faculty => faculty.Address)
                .Include(faculty => faculty.Students)
                .Include(faculty => faculty.FinancialHelpDocuments)
                .ToListAsync();
        }
    }
}
