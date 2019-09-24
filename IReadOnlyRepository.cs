using System.Collections.Generic;
using System.Threading.Tasks;
using Necessity.UnitOfWork.Predicates;

namespace Necessity.UnitOfWork
{
    public interface IReadOnlyRepository<TEntity, TKey>
    {
        Task<TEntity> Get(TKey key);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Find(Predicate predicate);
    }
}