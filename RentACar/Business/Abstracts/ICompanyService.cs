using Core.Utilities.Results.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface ICompanyService
{
    IDataResult<CompanyDetailDto> GetCompanyById(int id);
    IResult Add(Company company);
    IResult Update(Company company);
    IResult Delete(Company company);

}
