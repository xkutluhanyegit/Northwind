using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstracts;
using Entities.Concretes;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        Task<IDataResult<IEnumerable<Customer>>> GetAllAsync();
    }
}