using System;
using System.Collections.Concurrent;
using System.Data;
using Microsoft.Extensions.Logging;

namespace Necessity.UnitOfWork
{
    public class DbUnitOfWork : IUnitOfWork
    {
        public DbUnitOfWork(IDbConnection connection, ILogger logger)
        {
            Connection = connection;
            Logger = logger;
            Begin();
        }

        public Guid Id { get; } = Guid.NewGuid();
        public IDbConnection Connection { get; }
        public ILogger Logger { get; }
        public IDbTransaction Transaction { get; private set; }

        protected ConcurrentDictionary<Type, object> Instances = new ConcurrentDictionary<Type, object>();

        public IDbTransaction Begin()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Close();
                Connection.Open();
            }

            if (Transaction == null)
            {
                Transaction = Connection.BeginTransaction();
            }

            return Transaction;
        }

        public void Commit()
        {
            Transaction?.Commit();
            Dispose();
        }

        public void Rollback()
        {
            Transaction?.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Connection?.Dispose();
                Transaction.Dispose();
                Transaction = null;

                return;
            }

            Connection.Dispose();
        }

        protected TRepository Repository<TRepository>()
        {
            return (TRepository)Instances.GetOrAdd(
                typeof(TRepository),
                _ => (TRepository)Activator.CreateInstance(typeof(TRepository), Transaction, Logger));
        }

        ~DbUnitOfWork()
        {
            Dispose();
        }
    }
}