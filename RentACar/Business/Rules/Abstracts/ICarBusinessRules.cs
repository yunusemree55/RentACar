using Core.Business.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Abstracts;

public interface ICarBusinessRules : IBusinessRules
{

    void checkCarDescription(string carDescription);
    void checkCarDailyPrice(double price);
}
