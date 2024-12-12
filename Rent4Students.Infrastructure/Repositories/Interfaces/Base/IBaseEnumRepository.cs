namespace Rent4Students.Infrastructure.Repositories.Interfaces.Base
{
    public interface IBaseEnumRepository<TEntity>
    {
        Task<TEntity> Create(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetByIds(List<int> ids);
        Task Delete(int id);
    }
}
