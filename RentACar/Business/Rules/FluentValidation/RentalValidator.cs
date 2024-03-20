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

public class RentalValidator : AbstractValidator<Rental>
{
    private readonly IRentalDal _rentalDal;


    public RentalValidator(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;

        RuleFor(r => r.CarId).Must(CheckRentedCarIsDelivered).WithMessage(Message.CarIsNotReturned);


    }

    private bool CheckRentedCarIsDelivered(int id)
    {

        return _rentalDal.CheckRentedCarIsDelivered(id);

    }
}
