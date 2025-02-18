using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction has not been started.");

            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception)
            {
                await _transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction has not been started.");

            await _transaction.RollbackAsync();
            await DisposeTransactionAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public IGenericRepository<T> GetRepository<T>() where T : class,IEntity,new()
        {
            return new GenericRepository<T>(_context);
        }

        public void Dispose()
        {
            DisposeTransaction();
            _context.Dispose();
        }

        private void DisposeTransaction()
        {
            _transaction?.Dispose();
            _transaction = null;
        }

        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}