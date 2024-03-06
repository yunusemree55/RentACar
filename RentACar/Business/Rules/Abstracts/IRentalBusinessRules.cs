﻿using Core.Business.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Abstracts;

public interface IRentalBusinessRules : IBusinessRules
{
    void checkIfCarIsReturned(int carId);
}
