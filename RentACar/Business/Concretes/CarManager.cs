using Business.Abstracts;
using Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class CarManager : ICarService
{

    private readonly ICarDal _carDal;
    private readonly CarBusinessRules carBusinessRules;


    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
        carBusinessRules = new CarBusinessRules();
    }

    public List<Car> GetAll()
    {
        return _carDal.GetAll();
    }

    public List<Car> GetCarsByBrandId(int brandId)
    {
        return _carDal.GetAll(c => c.BrandId == brandId);
    }

    public List<Car> GetCarsByColorId(int colorId)
    {
        return _carDal.GetAll(c => c.ColorId == colorId);
    }

    public List<CarDetailDto> GetAllCarDetails()
    {
        return _carDal.GetAllCarDetails();
    }

    public CarDetailDto GetCarDetail(int id)
    {
        return _carDal.GetCarDetail(id);
    }

    public void Add(Car car)
    {
        carBusinessRules.checkCarDescription(car.Description);
        carBusinessRules.checkCarDailyPrice(car.DailyPrice);

        _carDal.Add(car);
    }

    public void Update(Car car)
    {
        _carDal.Update(car);
    }

    public void Delete(Car car)
    {
        _carDal.Delete(car);
    }

    
}
