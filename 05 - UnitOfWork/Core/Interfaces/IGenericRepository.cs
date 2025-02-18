using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class,IEntity,new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T,bool>> filter);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}