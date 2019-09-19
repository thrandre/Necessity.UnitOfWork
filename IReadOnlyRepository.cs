using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necessity.UnitOfWork
{
    public interface IReadOnlyRepository<TEntity, TKey>
    {
        Task<TEntity> Find(TKey key);
        Task<List<TEntity>> GetAll();
    }
}