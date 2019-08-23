using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necessity.UnitOfWork
{
    public interface IRepository<TEntity, TKey>
    {
        Task<TEntity> Find(TKey key);
        Task<List<TEntity>> GetAll();
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TKey key);
    }
}