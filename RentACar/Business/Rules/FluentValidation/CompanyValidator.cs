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

public class CompanyValidator : AbstractValidator<Company>
{
    private readonly ICompanyDal _companyDal;

    public CompanyValidator(ICompanyDal companyDal)
    {
        _companyDal = companyDal;

        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(3);

        RuleFor(c => c.Password).NotEmpty();
        RuleFor(c => c.Password).Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Email).EmailAddress();

        RuleFor(c => c.Email).Must(CheckEmailIfExistsBefore).WithMessage(Message.EmailIsAlreadyExists);

    }

    private bool CheckEmailIfExistsBefore(string arg)
    {
        return _companyDal.CheckCompanyEmailIfExistedBefore(arg);
    }
}
