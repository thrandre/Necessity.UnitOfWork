using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System;

namespace Necessity.UnitOfWork
{
    public class Repository<TEntity, TKey> : ReadOnlyRepository<TEntity, TKey>, IRepository<TEntity, TKey> where TEntity : class, new()
    {
        public Repository(
            IDbTransaction transaction,
            IQueryBuilder<TEntity, TKey> queryBuilder,
            Action<object> logger = null)
            : base(transaction, queryBuilder, logger)
        {
        }

        public new IQueryBuilder<TEntity, TKey> QueryBuilder => (IQueryBuilder<TEntity, TKey>)base.QueryBuilder;

        public virtual Task Create(TEntity entity)
        {
            var queryParams = new Dictionary<string, object>();
            var query = QueryBuilder.Create(entity, queryParams);

            Logger?.Invoke(new { Method = nameof(Create), Query = query, Params = queryParams });

            return Connection
                .ExecuteAsync(
                    query,
                    queryParams,
                    Transaction);
        }

        public virtual Task Update(TEntity entity)
        {
            var queryParams = new Dictionary<string, object>();
            var query = QueryBuilder.Update(entity, queryParams);

            Logger?.Invoke(new { Method = nameof(Update), Query = query, Params = queryParams });

            return Connection
                .ExecuteAsync(
                    query,
                    queryParams,
                    Transaction);
        }

        public virtual Task Upsert(TEntity entity, OnConflict onConflict)
        {
            var queryParams = new Dictionary<string, object>();
            var query = QueryBuilder.Upsert(entity, onConflict, queryParams);

            Logger?.Invoke(new { Method = nameof(Upsert), Query = query, Params = queryParams });

            return Connection
                .ExecuteAsync(
                    query,
                    queryParams,
                    Transaction);
        }

        public virtual Task Delete(TKey key)
        {
            var queryParams = new Dictionary<string, object>();
            var query = QueryBuilder.Delete(key, queryParams);

            Logger?.Invoke(new { Method = nameof(Delete), Query = query, Params = queryParams });

            return Connection
                .ExecuteAsync(
                    query,
                    queryParams,
                    Transaction);
        }
    }
}