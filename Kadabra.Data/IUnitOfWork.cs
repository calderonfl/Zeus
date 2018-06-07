using System;
using System.Data;
using System.Data.Entity.Core.Objects;
namespace Kadabra.Data
{
    public interface IUnitOfWork
    {
        bool IsInTransaction { get; }
        void SaveChanges();
        void SaveChanges(SaveOptions saveOptions);
        void BeginTransaction();
        void BeginTransaction(IsolationLevel isolationLevel);
        void RollBackTransaction();
        void CommitTransaction();
    }
}