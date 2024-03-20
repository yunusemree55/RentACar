using Business.Abstracts;
using Business.Rules.FluentValidation;
using Core.Aspects.Autofac;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
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

    public IDataResult<List<Color>> GetAll()
    {
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),"Tüm renkler listelendi");
    }

    public IDataResult<Color> GetColorById(int id)
    {
        return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id),"İlgili renk listelendi");
    }

    [ValidationAspect(typeof(ColorValidator),typeof(EfColorDal))]
    public IResult Add(Color color)
    {
        _colorDal.Add(color);
        return new SuccessResult("Renk sisteme kaydedildi");
    }

    public IResult Update(Color color)
    {
        _colorDal.Update(color);
        return new SuccessResult("Renk bilgileri güncellendi");
    }

    public IResult Delete(Color color)
    {
        _colorDal.Delete(color);
        return new SuccessResult("Renk sistemden silindi");
    }

}
