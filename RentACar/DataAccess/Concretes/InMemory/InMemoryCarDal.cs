using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.InMemory;

public class InMemoryCarDal : ICarDal
{
    private readonly List<Car> _cars;

    public InMemoryCarDal()
    {
        _cars = new List<Car>()
        {
            new Car{Id=1,BrandId=1,ColorId=1,Description="Focus",ModelYear=2020,DailyPrice=500},
            new Car{Id=2,BrandId=3,ColorId=2,Description="Golf",ModelYear=2019,DailyPrice=780},
            new Car{Id=3,BrandId=2,ColorId=3,Description="Corolla",ModelYear=2021,DailyPrice=400},
            new Car{Id=4,BrandId=2,ColorId=2,Description="Yaris",ModelYear=2017,DailyPrice=650},

        };


    }

    public List<Car> GetAll()
    {
        return _cars;
    }

    public List<Car> GetCarsByBrandId(int brandId)
    {
        return _cars.Where(c => c.BrandId == brandId).ToList();
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Delete(int id)
    {
        Car target = _cars.SingleOrDefault(c => c.Id == id);
        _cars.Remove(target);

    }

    public void Update(Car car)
    {
        Car target = _cars.SingleOrDefault(c => c.Id == car.Id);
        
        target.BrandId = car.BrandId;
        target.ColorId = car.ColorId;
        target.Description = car.Description;
        target.ModelYear = car.ModelYear;
        target.DailyPrice = car.DailyPrice;

    }
}
