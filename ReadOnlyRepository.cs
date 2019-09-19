using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using Dapper;

namespace Necessity.UnitOfWork
{
    public class ReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>
    {
        public ReadOnlyRepository(IDbTransaction transaction, IReadOnlyQueryBuilder<TEntity, TKey> queryBuilder)
        {
            Transaction = transaction;
            QueryBuilder = queryBuilder;
        }

        public IDbTransaction Transaction { get; }
        public IDbConnection Connection => Transaction.Connection;
        public IReadOnlyQueryBuilder<TEntity, TKey> QueryBuilder { get; }

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
    }
}