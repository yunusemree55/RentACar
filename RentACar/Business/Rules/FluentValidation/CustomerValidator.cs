using Business.Constants;
using DataAccess.Abstracts;
using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.FluentValidation;

public class CustomerValidator: AbstractValidator<Customer>
{
    private readonly ICustomerDal _customerDal;
    public CustomerValidator(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
        
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.FirstName).MinimumLength(3);

        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.LastName).MinimumLength(2);

        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Email).EmailAddress();

        RuleFor(c => c.Password).NotEmpty();
        RuleFor(c => c.Password).Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

        RuleFor(c => c.Email).Must(CheckCustomerEmailIfExistsBefore).WithMessage(Message.EmailIsAlreadyExists);

    }

    private bool CheckCustomerEmailIfExistsBefore(string arg)
    {
        return _customerDal.CheckCustomerEmailIfExistsBefore(arg);
    }
}
