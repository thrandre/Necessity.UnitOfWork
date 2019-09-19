using System.Collections.Generic;

namespace Necessity.UnitOfWork
{
    public interface IReadOnlyQueryBuilder<TEntity, TKey>
    {
        string Find(TKey key, Dictionary<string, object> queryParams);
        string GetAll(Dictionary<string, object> queryParams);
    }
}