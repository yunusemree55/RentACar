using Business.Abstracts;
using Business.Rules.FluentValidation;
using Core.Aspects.Autofac;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class CarManager : ICarService
{

    private readonly ICarDal _carDal;


    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"Tüm arabalar listelendi");
    }

    public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), "İlgili markaya ait arabalar listelendi");
    }

    public IDataResult<List<Car>> GetCarsByColorId(int colorId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId),"İlgili renge ait arabalar listelendi");
    }

    public IDataResult<List<CarDetailDto>> GetAllCarDetails()
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(),"Tüm araba bilgileri listelendi");
    }

    public IDataResult<CarDetailDto> GetCarDetail(int id)
    {
        return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetail(id),"İlgili araba bilgileri listelendi");
    }

    [ValidationAspect(typeof(CarValidator))]
    public IResult Add(Car car)
    {

        _carDal.Add(car);
        return new SuccessResult("Araba eklendi");
        
    }

    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult("Araba güncellendi");
    }

    public IResult Delete(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult("Araba silindi");
    }

    
}
