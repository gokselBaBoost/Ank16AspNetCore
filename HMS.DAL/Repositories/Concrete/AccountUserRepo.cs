using HMS.DAL.Context;
using HMS.DAL.Repositories.Abstract;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repositories.Concrete
{
    public class AccountUserRepo : Repo<AccountUser>
    {
        public AccountUserRepo(HmsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
