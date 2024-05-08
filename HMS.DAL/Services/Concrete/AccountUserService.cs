using HMS.DAL.Repositories.Abstract;
using HMS.DAL.Repositories.Concrete;
using HMS.DAL.Services.Abstract;
using HMS.DTO;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Services.Concrete
{
    public class AccountUserService : Service<AccountUser, AccountUserDto>
    {
        public AccountUserService(AccountUserRepo repo) : base(repo)
        {
        }
    }
}
