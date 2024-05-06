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
    public class CityRepo : Repo<City>
    {
        public CityRepo(HmsDbContext dbContext) : base(dbContext)
        {}

        public override IEnumerable<City> GetAll()
        {
            return _dbContext.Cities.Include(c => c.Country).ToList();
        }
    }
}
