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

public class BrandValidator : AbstractValidator<Brand>
{
    private readonly IBrandDal _brandDal;
    public BrandValidator(IBrandDal brandDal)
    {
        _brandDal = brandDal;

        RuleFor(b => b.Name).NotEmpty();
        RuleFor(b => b.Name).MinimumLength(2);
        RuleFor(b => b.Name).Must(CheckBrandNameIfExistsAlready).WithMessage(Message.BrandNameIsAlreadyExists);

    }

    private bool CheckBrandNameIfExistsAlready(string arg)
    {
        return _brandDal.CheckBrandNameIfExistsBefore(arg);
    }
}
