using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repositories.Abstract
{
    public interface IAccountUserRepo
    {
        AccountUser? FindLoginUser(string username, string password);
    }
}
