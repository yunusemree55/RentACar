using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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



    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Delete(Car car)
    {
        Car target = _cars.SingleOrDefault(c => c.Id == car.Id);
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

    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        throw new NotImplementedException();
    }
}
