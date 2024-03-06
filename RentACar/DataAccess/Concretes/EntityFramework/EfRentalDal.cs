using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework;

public class EfRentalDal : EfEntityRepository<Rental, RentACarContext>, IRentalDal
{
    public Rental GetUnreturnedCar(int carId)
    {
        using (RentACarContext context = new RentACarContext())
        {
            var result = context.Set<Rental>().Where(r => r.CarId == carId && r.ReturnDate == null);

            return result.SingleOrDefault();

        }
    }
}
