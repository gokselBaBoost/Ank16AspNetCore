using HMS.BLL.Managers.Abstract;
using HMS.DAL.Context;
using HMS.DAL.Services.Abstract;
using HMS.DAL.Services.Concrete;
using HMS.DAL.Services.Profiles;
using HMS.DTO;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Managers.Concrete
{
    public class CountryManager : Manager<CountryDto, Country>, ICountryManager
    {
        public CountryManager(CountryService countryService) : base(countryService)
        {}

        public IEnumerable<CountryDto> GetActiveList()
        {
            return ((ICountryService)_service).GetActiveList();
        }
    }
}
