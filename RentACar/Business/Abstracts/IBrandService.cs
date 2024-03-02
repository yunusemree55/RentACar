﻿using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IBrandService
{
    List<Brand> GetAll();
    Brand GetBrandById(int id);
    void Add(Brand brand);
    void Update(Brand brand);
    void Delete(Brand brand);
}
