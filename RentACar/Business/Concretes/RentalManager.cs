using Business.Abstracts;
using Business.Rules.FluentValidation;
using Core.Aspects.Autofac;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class RentalManager : IRentalService
{
    private readonly IRentalDal _rentalDal;

    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }


    [ValidationAspect(typeof(RentalValidator), typeof(EfRentalDal))]
    public IResult Add(Rental rental)
    {

        rental.RentDate = DateTime.Now;
        _rentalDal.Add(rental);
        return new SuccessResult($"Araba {rental.RentDate.Day}/{rental.RentDate.Month}/{rental.RentDate.Year} tarihinde kiralandı");
    }

    public IResult RemoveCar(Rental rental)
    {
        Rental target = _rentalDal.Get(r => r.Id == rental.Id);
        target.ReturnDate = DateTime.Now;
        _rentalDal.Update(target);

        return new SuccessResult("Araba teslimi gerçekleştirildi");
    }
}
