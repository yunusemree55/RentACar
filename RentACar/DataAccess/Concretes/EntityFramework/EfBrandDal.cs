using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework;

public class EfBrandDal : EfEntityRepository<Brand, RentACarContext>, IBrandDal
{
    public bool CheckBrandNameIfExistsBefore(string name)
    {
        using (RentACarContext context = new RentACarContext())
        {
            var result = from brand in context.Brands
                         where brand.Name == name
                         select new Brand();

            return result.IsNullOrEmpty();

        }
    }
}
