using Core.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs;

public class CompanyDetailDto: IDto
{
    public int Id {  get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
