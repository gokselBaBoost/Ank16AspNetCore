using HMS.BLL.Managers.Abstract;
using HMS.DAL.Services.Abstract;
using HMS.DAL.Services.Concrete;
using HMS.DTO;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Managers.Concrete
{
    public class AccountUserManager : Manager<AccountUserDto, AccountUser>, IAccountUserManager
    {
        public AccountUserManager(AccountUserService service) : base(service)
        {
        }

        public AccountUserDto? FindLoginUser(string username, string password)
        {
            return (base._service as IAccountUserService).FindLoginUser(username, password);
        }
    }
}
