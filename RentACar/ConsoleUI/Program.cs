
using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Concretes.InMemory;
using Entities.Concretes;


CarManager carManager = new CarManager(new EfCarDal());
//CarTest();
//BrandAddTest();
//ColorAddTest();
//CarAddTest();

//CarDetailsTest();

Console.WriteLine(carManager.GetCarDetail(3).BrandName);

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var car in carManager.GetAll())
    {
        Console.WriteLine(car.Description);
    }
}

static void BrandAddTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    brandManager.Add(new Brand { Name = "Mercedes" });
}

static void ColorAddTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    colorManager.Add(new Color { Name = "Gri" });
}

static void CarAddTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    carManager.Add(new Car { BrandId = 2, ColorId = 1, Description = "Benz", ModelYear = 2018, DailyPrice = 750 });
}

static void CarDetailsTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var car in carManager.GetAllCarDetails())
    {
        Console.WriteLine($"{car.Id}->{car.BrandName} {car.Description} adlı arabanın rengi {car.ColorName}");
    }
}