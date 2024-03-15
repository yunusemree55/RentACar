
using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Concretes.InMemory;
using Entities.Concretes;


CarManager carManager = new CarManager(new EfCarDal());
CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
RentalManager rentalManager = new RentalManager(new EfRentalDal());

//customerManager.Add(new Customer { FirstName = "Nedim", LastName = "Görgü", Email = "ng@gmail.com", Password = "ng123" });
Console.WriteLine(DateTime.Now.Year);
//Console.WriteLine(customerManager.GetCustomerById(2).Data.Email.Length);

//CarTest();
//BrandAddTest();
//ColorAddTest();
//CarAddTest();

//CarDetailsTest();
//Console.WriteLine(carManager.GetCarDetail(1).Data.BrandName);

//RentalAddTest();

//CompanyAddTest();

//rentalManager.RemoveCar(new Rental { Id = 2, CustomerId = 1, CarId = 2 , RentDate = DateTime.Now  });

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
    carManager.Add(new Car { BrandId = 2, ColorId = 1, CompanyId = 5, Description = "Benz", ModelYear = 2019, DailyPrice = 750 });
}

static void CarDetailsTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var car in carManager.GetAllCarDetails().Data)
    {
        Console.WriteLine($"{car.Id}->{car.BrandName} {car.Description} adlı arabanın rengi {car.ColorName} ve arabanın sahibi {car.CompanyName} adlı şirkettir");
    }
}

static void RentalAddTest()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());
    rentalManager.Add(new Rental { CustomerId = 1003, CarId = 3 });
}

static void CompanyAddTest()
{
    CompanyManager companyManager = new CompanyManager(new EfCompanyDal());

    companyManager.Add(new Company { Name = "XYZ Şirketi", Email = "xyz@gmail.com", Password = "xyz123" });
}