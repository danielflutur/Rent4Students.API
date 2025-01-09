namespace Rent4Students.Infrastructure.Repositories.Interfaces.Base
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> Create(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
