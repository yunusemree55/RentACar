
using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Concretes.InMemory;
using Entities.Concretes;

CarManager carManager = new CarManager(new EfCarDal());
ColorManager colorManager = new ColorManager(new EfColorDal());

foreach (var car in carManager.GetAll())
{
    //Console.WriteLine(car.Description);
}

Car car1 = new Car { ColorId = 1 , BrandId = 1, Description = "", DailyPrice = 0 };

//carManager.Add(car1);