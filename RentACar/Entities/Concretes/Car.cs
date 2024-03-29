﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Car : IEntity
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public int CompanyId { get; set; }
    public string Description { get; set; }
    public int ModelYear { get; set; }
    public double DailyPrice { get; set; }

    public Color Color { get; set; }

}
