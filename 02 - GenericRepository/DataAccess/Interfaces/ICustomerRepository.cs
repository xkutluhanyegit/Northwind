using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Entities.Concretes;

namespace DataAccess.Interfaces
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        
    }
}