using DataAccess.Abstracts;
using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.FluentValidation;

public class RentalValidator : AbstractValidator<Rental>
{
    private readonly IRentalDal _rentalDal;


    public RentalValidator(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;

        RuleFor(r => r.CarId).Must(CheckRentedCarIsReturned).WithMessage("Araba henüz teslim edilmemiştir.");


    }

    private bool CheckRentedCarIsReturned(int id)
    {

        return _rentalDal.CheckRentedCarIsReturned(id);

    }
}
