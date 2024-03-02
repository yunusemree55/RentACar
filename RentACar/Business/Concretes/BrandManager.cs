using Business.Abstracts;
using Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public void Add(Brand brand)
    {
        _brandDal.Add(brand);
    }

    public void Delete(Brand brand)
    {
        _brandDal.Delete(brand);
    }

    public List<Brand> GetAll()
    {
        return _brandDal.GetAll();
    }

    public Brand GetBrandById(int id)
    {
        return _brandDal.Get(b => b.Id == id);
    }

    public void Update(Brand brand)
    {
        _brandDal.Update(brand);
    }
}
