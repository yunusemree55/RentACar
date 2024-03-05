using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concretes;

public class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult(T data, string message) : base(false, data, message)
    {

    }

    public ErrorDataResult(T data) : base(false, data)
    {

    }

}
