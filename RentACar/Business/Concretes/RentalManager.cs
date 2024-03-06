using Business.Abstracts;
using Business.Rules.Abstracts;
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

public class RentalManager : IRentalService
{
    private readonly IRentalDal _rentalDal;
    private readonly IRentalBusinessRules _rentalBusinessRules;

    public RentalManager(IRentalDal rentalDal,IRentalBusinessRules rentalBusinessRules)
    {
        _rentalDal = rentalDal;
        _rentalBusinessRules = rentalBusinessRules;
    }

    public IResult Add(Rental rental)
    {
        _rentalBusinessRules.checkIfCarIsReturned(rental.CarId);
        
        rental.RentDate = DateTime.Now;
        _rentalDal.Add(rental);
        return new SuccessResult($"Araba {rental.RentDate.Day}/{rental.RentDate.Month}/{rental.RentDate.Year} tarihinde kiralandı");
    }

    public IResult RemoveCar(Rental rental)
    {
        rental.ReturnDate = DateTime.Now;
        _rentalDal.Update(rental);

        return new SuccessResult("Araba teslimi gerçekleştirildi");
    }
}
