using Business.Rules.Abstracts;
using Core.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Concretes;

public class RentalBusinessRules : IRentalBusinessRules
{
    private readonly IRentalDal _rentalDal;
    public RentalBusinessRules(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }
    public void checkIfCarIsReturned(int carId)
    {
        Rental result = _rentalDal.GetUnreturnedCar(carId);

        if(result == null)
        {
            return;
        }
        else if(result.ReturnDate == null)
        {
            throw new Exception("Araba henüz teslim edilmedi");
        }


    }
}
