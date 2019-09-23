using System.Collections.Generic;

namespace Necessity.UnitOfWork
{

    public interface IQueryBuilder<TEntity, TKey> : IReadOnlyQueryBuilder<TEntity, TKey>
    {
        string Create(TEntity entity, Dictionary<string, object> queryParams);
        string Update(TEntity entity, Dictionary<string, object> queryParams);
        string Upsert(TEntity entity, OnConflict onConflict, Dictionary<string, object> queryParams);
        string Delete(TKey key, Dictionary<string, object> queryParams);
    }
}