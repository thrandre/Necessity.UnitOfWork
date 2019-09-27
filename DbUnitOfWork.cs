using System;
using System.Collections.Concurrent;
using System.Data;
using Microsoft.Extensions.Logging;

namespace Necessity.UnitOfWork
{
    public class DbUnitOfWork : IUnitOfWork
    {
        private bool _disposed;

        public DbUnitOfWork(IDbConnection connection, ILogger logger)
        {
            Connection = connection;
            Logger = logger;

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            Transaction = Connection.BeginTransaction();
        }

        public Guid Id { get; } = Guid.NewGuid();
        public IDbConnection Connection { get; private set; }
        public IDbTransaction Transaction { get; private set; }
        public ILogger Logger { get; }

        protected ConcurrentDictionary<Type, object> Instances = new ConcurrentDictionary<Type, object>();

        public void Commit()
        {
            try
            {
                Transaction.Commit();
            }
            catch
            {
                Transaction.Rollback();
                throw;
            }
            finally
            {
                Transaction.Dispose();
                Transaction = Connection.BeginTransaction();
            }
        }

        protected TRepository Repository<TRepository>()
        {
            return (TRepository)Instances.GetOrAdd(
                typeof(TRepository),
                _ => (TRepository)Activator.CreateInstance(typeof(TRepository), Transaction, Logger));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (Transaction != null)
                {
                    Transaction.Dispose();
                    Transaction = null;
                }

                if (Connection != null)
                {
                    Connection.Dispose();
                    Connection = null;
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DbUnitOfWork()
        {
            Dispose(false);
        }
    }
}