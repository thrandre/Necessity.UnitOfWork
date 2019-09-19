using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace Necessity.UnitOfWork
{
    public class Repository<TEntity, TKey> : ReadOnlyRepository<TEntity, TKey>, IRepository<TEntity, TKey> where TEntity : class, new()
    {
        public Repository(IDbTransaction transaction, IQueryBuilder<TEntity, TKey> queryBuilder)
            : base(transaction, queryBuilder)
        {
        }

        public new IQueryBuilder<TEntity, TKey> QueryBuilder => (IQueryBuilder<TEntity, TKey>)base.QueryBuilder;

        public virtual Task Create(TEntity entity)
        {
            var queryParams = new Dictionary<string, object>();

            return Connection
                .ExecuteAsync(
                    QueryBuilder.Create(entity, queryParams),
                    queryParams,
                    Transaction);
        }

        public virtual Task Update(TEntity entity)
        {
            var queryParams = new Dictionary<string, object>();

            return Connection
                .ExecuteAsync(
                    QueryBuilder.Update(entity, queryParams),
                    queryParams,
                    Transaction);
        }

        public virtual Task Delete(TKey key)
        {
            var queryParams = new Dictionary<string, object>();

            return Connection
                .ExecuteAsync(
                    QueryBuilder.Delete(key, queryParams),
                    queryParams,
                    Transaction);
        }
    }
}