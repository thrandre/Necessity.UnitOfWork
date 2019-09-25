using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using Dapper;
using Necessity.UnitOfWork.Predicates;
using System;

namespace Necessity.UnitOfWork
{
    public abstract class ReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>
    {
        public ReadOnlyRepository(
            IDbTransaction transaction,
            IReadOnlyQueryBuilder<TEntity, TKey> queryBuilder,
            Action<object> logger)
        {
            Transaction = transaction;
            QueryBuilder = queryBuilder;
            Logger = logger;
        }

        public IDbTransaction Transaction { get; }
        public IDbConnection Connection => Transaction.Connection;
        public IReadOnlyQueryBuilder<TEntity, TKey> QueryBuilder { get; }

        protected Action<object> Logger { get; }

        public virtual async Task<TEntity> Get(TKey key)
        {
            var queryParams = new Dictionary<string, object>();
            var query = QueryBuilder.Get(key, queryParams);

            Logger?.Invoke(new { Method = nameof(Get), Query = query, Params = queryParams });

            return (await Connection
                .QueryAsync<TEntity>(
                    query,
                    queryParams,
                    Transaction))
                .Single();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            var queryParams = new Dictionary<string, object>();
            var query = QueryBuilder.GetAll(queryParams);

            Logger?.Invoke(new { Method = nameof(GetAll), Query = query, Params = queryParams });

            return (await Connection
                .QueryAsync<TEntity>(
                    query,
                    queryParams,
                    Transaction))
                .ToList();
        }

        public virtual async Task<List<TEntity>> Find(Predicate predicate)
        {
            var queryParams = new Dictionary<string, object>();
            var query = QueryBuilder.Find(predicate, queryParams);

            Logger?.Invoke(new { Method = nameof(Find), Query = query, Params = queryParams });

            return (await Connection
                .QueryAsync<TEntity>(
                    query,
                    queryParams,
                    Transaction))
                .ToList();
        }
    }
}