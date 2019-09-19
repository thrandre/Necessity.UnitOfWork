using System.Threading.Tasks;

namespace Necessity.UnitOfWork
{

    public interface IRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>
    {
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TKey key);
    }
}