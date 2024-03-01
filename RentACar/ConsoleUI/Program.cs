
using Business.Concretes;
using DataAccess.Concretes.InMemory;
using Entities.Concretes;

CarManager carManager = new CarManager(new InMemoryCarDal());

// Listing cars ->

foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}

//Adding car ->

Car car1 = new Car { Id = 5,BrandId = 1,ColorId = 2,Description = "Mustang", ModelYear = 2008, DailyPrice = 570 };

carManager.Add(car1);

// Listing cars by BrandId ->

foreach (Car car in carManager.GetCarsByBrandId(1))
{
    Console.WriteLine(car.Description);
}

// Deleting Car ->

carManager.Delete(2);

foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}
