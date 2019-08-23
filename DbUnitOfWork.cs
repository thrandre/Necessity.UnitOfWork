using System;
using System.Data;

namespace Necessity.UnitOfWork
{
    public class DbUnitOfWork : IUnitOfWork
    {
        public DbUnitOfWork(IDbConnection connection)
        {
            Connection = connection;
            Begin();
        }

        public Guid Id { get; } = Guid.NewGuid();
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; private set; }

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

        ~DbUnitOfWork()
        {
            Dispose();
        }
    }
}