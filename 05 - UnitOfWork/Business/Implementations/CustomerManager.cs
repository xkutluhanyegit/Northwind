using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Core.Interfaces;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Interfaces;
using Entities.Concretes;

namespace Business.Implementations
{
    public class CustomerManager : ICustomerService
    {
        IUnitOfWork _unitOfWork;
        public CustomerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<IEnumerable<Customer>>> GetAllAsync()
        {
            var result = await _unitOfWork.GetRepository<Customer>().GetAllAsync();
            return new SuccessDataResult<IEnumerable<Customer>>(result);
        }
    }
}