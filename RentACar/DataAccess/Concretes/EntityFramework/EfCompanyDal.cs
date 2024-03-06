using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework;

public class EfCompanyDal : EfEntityRepository<Company, RentACarContext>, ICompanyDal
{
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
}
