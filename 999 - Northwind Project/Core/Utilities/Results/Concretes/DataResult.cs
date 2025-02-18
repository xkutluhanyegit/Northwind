using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstracts;

namespace Core.Utilities.Results.Concretes
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data {get;}

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
    }
}