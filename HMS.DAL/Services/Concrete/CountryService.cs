using HMS.DAL.Context;
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
    public class CountryService : Service<Country, CountryDto>
    {
        public CountryService(HmsDbContext context)
        {
            _repo = new CountryRepo(context);
        }
    }
}
