using Core.Utilities.Results.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface ICarService
{
    IDataResult<List<Car>> GetAll();
    IDataResult<List<Car>> GetCarsByBrandId(int brandId);
    IDataResult<List<Car>> GetCarsByColorId(int colorId);
    IDataResult<List<CarDetailDto>> GetAllCarDetails();
    IDataResult<CarDetailDto> GetCarDetail(int id);
    IResult Add(Car car);
    IResult Update(Car car);
    IResult Delete(Car car);

}
