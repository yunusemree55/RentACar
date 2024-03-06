using Business.Abstracts;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class CustomerManager : ICustomerService
{
    private readonly ICustomerDal _customerDal;

    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public IResult Add(Customer customer)
    {
        _customerDal.Add(customer);
        return new SuccessResult($"{customer.FirstName} {customer.LastName} adlı müşteri sisteme eklendi");
    }

    public IResult Delete(Customer customer)
    {
        _customerDal.Delete(customer);
        return new SuccessResult($"{customer.FirstName} {customer.LastName} adlı müşteri sistemden silindi");

    }

    public IDataResult<List<Customer>> GetAll()
    {

        return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),"Tüm müşteriler listelendi");
    }

    public IDataResult<Customer> GetCustomerById(int id)
    {
        return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id),"İlgili müşteri listelendi");
    }

    public IResult Update(Customer customer)
    {
        _customerDal.Update(customer);
        return new SuccessResult($"{customer.FirstName} {customer.LastName} adlı müşterinin bilgileri güncellendi");
    }
}
