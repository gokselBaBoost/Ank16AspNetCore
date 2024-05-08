using HMS.DAL.Context;
using HMS.DAL.Repositories.Abstract;
using HMS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repositories.Concrete
{
    public class MenuRepo : Repo<Menu>
    {
        public MenuRepo(HmsDbContext dbContext) : base(dbContext)
        {}

        public override IEnumerable<Menu> GetAll()
        {
            return base._dbContext.Menus
                                  .Include( m => m.SubMenu)
                                  .ToList();
        }
    }
}
