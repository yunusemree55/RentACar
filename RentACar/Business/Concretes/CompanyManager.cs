using Business.Abstracts;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class CompanyManager : ICompanyService
{
    private readonly ICompanyDal _companyDal;

    public CompanyManager(ICompanyDal companyDal)
    {
        _companyDal = companyDal;
    }

    public IResult Add(Company company)
    {

        _companyDal.Add(company);
        return new SuccessResult("Şirket sisteme kaydedildi");
    }

    public IResult Delete(Company company)
    {

        _companyDal.Delete(company);
        return new SuccessResult("Şirket sistemden silindi");
    }

    public IDataResult<CompanyDetailDto> GetCompanyById(int id)
    {

        return new SuccessDataResult<CompanyDetailDto>(_companyDal.GetCompanyDetailById(id),"İlgili şirket listelendi");
    }

    public IResult Update(Company company)
    {

        _companyDal.Update(company);
        return new SuccessResult("İlgili şirket bilgileri güncellendi");
    }
}
