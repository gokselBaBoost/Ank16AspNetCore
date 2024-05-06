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
    public class CountryRepo : Repo<Country>, ICountryRepo
    {
        public CountryRepo(HmsDbContext dbContext) : base(dbContext)
        {}

        //Özelleştirilen metotlar burada olacaktır.

        public IEnumerable<Country> GetActiveList()
        {
            return base._dbContext.Countries.Where(c => c.IsActive).ToList();
        }

        public override Country? Get(int id)
        {
            return base._dbContext.Countries.Include(c => c.Cities).SingleOrDefault(c => c.Id == id);
        }

    }
}
