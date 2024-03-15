using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCustomerDal : EfEntityRepository<Customer, RentACarContext>, ICustomerDal
    {
        public bool CheckCustomerEmailIfExistsBefore(string email)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from customer in context.Customers
                             where customer.Email == email
                             select new Customer();

                return result.IsNullOrEmpty();

            }
        }
    }
}
