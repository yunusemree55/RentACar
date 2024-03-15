using Core.DataAccess.EntityFramework;
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

public class EfColorDal : EfEntityRepository<Color, RentACarContext>, IColorDal
{
    public bool CheckColorNameIfExistsBefore(string name)
    {
        using (RentACarContext context = new RentACarContext())
        {
            var result = from color in context.Colors
                         where color.Name == name
                         select new Color();

            return result.IsNullOrEmpty();
        }
    }
}
