using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class UniversityRepository : BaseRepository<University>, IUniversityRepository
    {
        public UniversityRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<University> GetById(Guid id)
        {
            return await _dbSet
                .Where(university => university.Id == id)
                .Include(university => university.ProfilePhoto)
                .Include(university => university.Address)
                .Include(university => university.Faculties)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<University>> GetAll()
        {
            return await _dbSet
                .Where(university => university.IsDeleted == false)
                .Include(university => university.ProfilePhoto)
                .Include(university => university.Address)
                .Include(university => university.Faculties)
                .ToListAsync();
        }
    }
}
