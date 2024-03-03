using Business.Abstracts;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class ColorManager : IColorService
{

    private readonly IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }

    public List<Color> GetAll()
    {
        return _colorDal.GetAll();
    }

    public Color GetColorById(int id)
    {
        return _colorDal.Get(c => c.Id == id);
    }

    public void Add(Color color)
    {
        _colorDal.Add(color);
    }

    public void Update(Color color)
    {
        _colorDal.Update(color);
    }

    public void Delete(Color color)
    {
        _colorDal.Delete(color);
    }

}
