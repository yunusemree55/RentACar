using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework;

public class EfCompanyDal : EfEntityRepository<Company, RentACarContext>, ICompanyDal
{
    public bool CheckCompanyEmailIfExistedBefore(string email)
    {
        using (RentACarContext context = new RentACarContext())
        {
            var result = from company in context.Companies
                         where company.Email == email
                         select new Company();

            return result.IsNullOrEmpty();
        }
    }

    public CompanyDetailDto GetCompanyDetailById(int id)
    {
        using (RentACarContext context = new RentACarContext())
        {
            var result = from company in context.Companies
                                             where company.Id == id
                                             select new CompanyDetailDto { Id = company.Id, Name = company.Name, Email = company.Email };

            return result.FirstOrDefault();

        }
    }

    public CompanyWithCarDetailDto GetCompanyWithCarDetail(int id)
    {
        using (RentACarContext context = new RentACarContext())
        {

            var result = from company in context.Companies
                         where company.Id == id 
                         select new CompanyWithCarDetailDto
                         {
                             Id = company.Id,
                             Name = company.Name,
                             Email = company.Email,
                             Cars = (
                             from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             where car.CompanyId == id
                             select new CarDetailDto
                             {
                                Id = car.Id,
                                BrandName = brand.Name,
                                ColorName = color.Name,
                                CompanyName = company.Name,
                                Description = car.Description,
                                ModelYear = car.ModelYear,
                                DailyPrice = car.DailyPrice,
                             }).ToList()


                         };

            return result.FirstOrDefault();

        }

    }
}
                                     