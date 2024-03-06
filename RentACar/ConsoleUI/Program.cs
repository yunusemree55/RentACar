
using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Concretes.InMemory;
using Entities.Concretes;


CarManager carManager = new CarManager(new EfCarDal());
CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

//customerManager.Add(new Customer { FirstName = "Enes Emir", LastName = "Çiçek", Email = "enesemir@gmail.com", Password = "ee123" });

//Console.WriteLine(customerManager.GetCustomerById(2).Data.Email.Length);

//CarTest();
//BrandAddTest();
//ColorAddTest();
//CarAddTest();

//CarDetailsTest();

//Console.WriteLine(carManager.GetCarDetail(1).Data.BrandName);

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var car in carManager.GetAll().Data)
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
    colorManager.Add(new Color { Name = "Siyah" });
}

static void CarAddTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    carManager.Add(new Car { BrandId = 2, ColorId = 1, Description = "Benz", ModelYear = 2020, DailyPrice = 750 });
}

static void CarDetailsTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var car in carManager.GetAllCarDetails().Data)
    {
        Console.WriteLine($"{car.Id}->{car.BrandName} {car.Description} adlı arabanın rengi {car.ColorName}");
    }
}