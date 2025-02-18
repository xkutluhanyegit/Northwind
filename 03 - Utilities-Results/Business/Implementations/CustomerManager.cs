using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Interfaces;
using Entities.Concretes;

namespace Business.Implementations
{
    public class CustomerManager : ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IDataResult<IEnumerable<Customer>>> GetAllAsync()
        {
            var result = await _customerRepository.GetAllAsync();
            return new SuccessDataResult<IEnumerable<Customer>>(result);
        }
    }
}