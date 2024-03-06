using Core.Utilities.Results.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IRentalService
{
    IResult Add(Rental rental);
    IResult RemoveCar(Rental rental);
}
