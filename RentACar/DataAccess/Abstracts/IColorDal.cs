using Core.DataAccess;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework;

public interface IColorDal : IEntityRepository<Color>
{
    bool CheckColorNameIfExistsBefore(string name);
}
