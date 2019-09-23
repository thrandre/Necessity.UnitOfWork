using System.Collections.Generic;
using Data.Predicates;

namespace Necessity.UnitOfWork
{
    public interface IReadOnlyQueryBuilder<TEntity, TKey>
    {
        string Get(TKey key, Dictionary<string, object> queryParams);
        string GetAll(Dictionary<string, object> queryParams);
        string Find(Predicate predicate, Dictionary<string, object> queryParams);
    }
}