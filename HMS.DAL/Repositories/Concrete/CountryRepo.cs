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
    internal class CountryRepo : Repo<Country>
    {
        public CountryRepo(HmsDbContext dbContext) : base(dbContext)
        { }

        //Özelleştirilen metotlar burada olacaktır.
    }
}
