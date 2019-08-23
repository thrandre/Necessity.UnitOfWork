using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using Dapper;

namespace Necessity.UnitOfWork
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, new()
    {
        public Repository(IDbTransaction transaction, IQueryBuilder<TEntity, TKey> queryBuilder)
        {
            Transaction = transaction;
            QueryBuilder = queryBuilder;
        }

        public IDbTransaction Transaction { get; }
        public IDbConnection Connection => Transaction.Connection;
        public IQueryBuilder<TEntity, TKey> QueryBuilder { get; }

        public virtual async Task<TEntity> Find(TKey key)
        {
            var queryParams = new Dictionary<string, object>();

            return (await Connection
                .QueryAsync<TEntity>(
                    QueryBuilder.Find(
                        key,
                        queryParams),
                    queryParams,
                    Transaction))
                .Single();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            var queryParams = new Dictionary<string, object>();

            return (await Connection
                .QueryAsync<TEntity>(
                    QueryBuilder.GetAll(queryParams),
                    queryParams,
                    Transaction))
                .ToList();
        }

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