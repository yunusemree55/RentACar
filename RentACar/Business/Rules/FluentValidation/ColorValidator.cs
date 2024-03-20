using Business.Constants;
using Core.DataAccess.EntityFramework;
using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.FluentValidation;

public class ColorValidator : AbstractValidator<Color>
{

    private readonly IColorDal _colorDal;

    public ColorValidator(IColorDal colorDal)
    {
        _colorDal = colorDal;

        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(2);

        RuleFor(c => c.Name).Must(CheckColorNameIfExistsAlready).WithMessage(Message.ColorNameIsAlreadyExists);

    }

    private bool CheckColorNameIfExistsAlready(string arg)
    {
        return _colorDal.CheckColorNameIfExistsBefore(arg);
    }
}
