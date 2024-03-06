using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstracts;

public interface IUser
{
    int Id { get; set; }
    string Email { get; set; }
    string Password { get; set; }

}
