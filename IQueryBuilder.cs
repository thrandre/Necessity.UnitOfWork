using System.Collections.Generic;

namespace Necessity.UnitOfWork
{
    public interface IQueryBuilder<TEntity, TKey>
    {
        string Find(TKey key, Dictionary<string, object> queryParams);
        string GetAll(Dictionary<string, object> queryParams);
        string Create(TEntity entity, Dictionary<string, object> queryParams);
        string Update(TEntity entity, Dictionary<string, object> queryParams);
        string Delete(TKey key, Dictionary<string, object> queryParams);
    }
}