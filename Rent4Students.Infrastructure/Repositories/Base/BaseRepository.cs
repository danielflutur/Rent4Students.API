using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities.Base;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Interfaces.Base;

namespace Rent4Students.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext applicationDbContext)
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

        public virtual async Task Delete(Guid id)
        {
            _dbSet.Where(e => e.Id == id)
                .FirstOrDefault().IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet
               .Where(entity => entity.Id == id)
               .FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
