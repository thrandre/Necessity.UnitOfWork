using System;
using System.Data;

namespace Necessity.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Guid Id { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        IDbTransaction Begin();
        void Commit();
        void Rollback();
    }
}