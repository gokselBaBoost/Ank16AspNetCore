using HMS.DTO;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Managers.Abstract
{
    public interface IAccountUserManager
    {
        AccountUserDto? FindLoginUser(string username, string password);
    }
}
