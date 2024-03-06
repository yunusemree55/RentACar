using Business.Rules.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Concretes;

public class CarBusinessRules : ICarBusinessRules
{

    public void checkCarDescription(string carDescription)
    {
        if (carDescription.Length < 2)
        {
            throw new Exception("Araba açıklaması en az 2 karakter olmalıdır");
        }
    }

    public void checkCarDailyPrice(double price)
    {
        if (price <= 0)
        {
            throw new Exception("Araba günlük fiyatı 0'dan büyük olmalıdır");
        }
    }


}
