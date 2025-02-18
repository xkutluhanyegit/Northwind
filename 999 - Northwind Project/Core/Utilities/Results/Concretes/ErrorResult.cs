using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concretes
{
    public class ErrorResult:Result
    {
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string message) :base(true,message)
        {
            
        }
    }
}