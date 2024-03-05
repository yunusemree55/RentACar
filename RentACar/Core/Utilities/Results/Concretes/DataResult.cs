using Core.Utilities.Results.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concretes;

public class DataResult<T> : Result,IDataResult<T> 
{
    public T Data { get; }

    public DataResult(bool success,T data,string message):base(success,message)
    {
        Data = data;        
    }

    public DataResult(bool success, T data):base(success)
    {
            Data = data;
    }


}
