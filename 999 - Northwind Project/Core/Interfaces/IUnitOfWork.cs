using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class,IEntity,new();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void BeginTransaction();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}