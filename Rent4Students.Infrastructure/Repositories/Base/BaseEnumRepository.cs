using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities.Base;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Interfaces.Base;

namespace Rent4Students.Infrastructure.Repositories.Base
{
    public class BaseEnumRepository<TEntity> : IBaseEnumRepository<TEntity> where TEntity : BaseEnumEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseEnumRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task Delete(int id)
        {
            _dbSet.Remove(_dbSet.Where(entity => entity.Id == id).FirstOrDefault());
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _dbSet
               .Where(entity => entity.Id == id)
               .FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetByIds(List<int> ids)
        {
            return await _dbSet
                .Where( entity => ids.Contains(entity.Id))
                .ToListAsync();
        }
    }
}
