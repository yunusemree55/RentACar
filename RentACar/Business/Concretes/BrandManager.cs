using Business.Abstracts;
using Business.Rules;
using Business.Rules.FluentValidation;
using Core.Aspects.Autofac;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
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

    [ValidationAspect(typeof(BrandValidator),typeof(EfBrandDal))]
    public IResult Add(Brand brand)
    {

        _brandDal.Add(brand);
        return new SuccessResult("Marka eklendi");
    }

    public IResult Delete(Brand brand)
    {
        _brandDal.Delete(brand);
        return new SuccessResult("Marka silindi");
    }

    public IDataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),"Tüm markalar listelendi");
    }

    public IDataResult<Brand> GetBrandById(int id)
    {
        return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
    }

    public IResult Update(Brand brand)
    {
        _brandDal.Update(brand);
        return new SuccessResult("Marka güncellendi");
    }
}
