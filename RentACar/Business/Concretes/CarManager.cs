using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
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

    public List<Car> GetAll()
    {
        return _carDal.GetAll();
    }

    public List<Car> GetCarsByBrandId(int brandId)
    {
        return _carDal.GetCarsByBrandId(brandId);
    }
    public void Add(Car car)
    {
        _carDal.Add(car);
    }

    public void Delete(int id)
    {
        _carDal.Delete(id);
    }

    public void Update(Car car)
    {
        _carDal.Update(car);
    }
}
