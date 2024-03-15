using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.FluentValidation;

public class CarValidator : AbstractValidator<Car>
{

    public CarValidator()
    {
        
        RuleFor(c => c.BrandId).NotEmpty();
        RuleFor(c => c.ColorId).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();

        RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(1970);
        RuleFor(c => c.ModelYear).LessThanOrEqualTo(DateTime.Now.Year);

        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Description).MinimumLength(3);

        RuleFor(c => c.DailyPrice).NotEmpty();
        RuleFor(c => c.DailyPrice).GreaterThan(0);
    }

}
