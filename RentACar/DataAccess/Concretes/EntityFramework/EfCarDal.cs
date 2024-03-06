using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework;

public class EfCarDal : EfEntityRepository<Car, RentACarContext>, ICarDal
{
    public List<CarDetailDto> GetAllCarDetails()
    {
        using (RentACarContext context = new RentACarContext())
        {
            var result = from car in context.Cars
                         join brand in context.Brands
                         on car.BrandId equals brand.Id
                         join color in context.Colors
                         on car.ColorId equals color.Id
                         join company in context.Companies
                         on car.CompanyId equals company.Id
                         select new CarDetailDto {
                             Id = car.Id,
                             BrandName = brand.Name,
                             ColorName = color.Name,
                             CompanyName = company.Name,
                             Description = car.Description, 
                             ModelYear = car.ModelYear, 
                             DailyPrice = car.DailyPrice 
                         };

            return result.ToList();
            
        }

    }

    public CarDetailDto GetCarDetail(int id)
    {
        using (RentACarContext context = new RentACarContext())
        {
            var result = from car in context.Cars
                         join brand in context.Brands
                         on car.BrandId equals brand.Id
                         join color in context.Colors
                         on car.ColorId equals color.Id
                         join company in context.Companies
                         on car.CompanyId equals company.Id
                         where car.Id == id
                         select new CarDetailDto
                         {
                             Id = car.Id,
                             BrandName = brand.Name,
                             ColorName = color.Name,
                             CompanyName = company.Name,
                             Description = car.Description,
                             ModelYear = car.ModelYear,
                             DailyPrice = car.DailyPrice
                         };

            return result.SingleOrDefault();

        }


    }
}
