using AutoMapper;
using HMS.DAL.Context;
using HMS.DAL.Repositories.Abstract;
using HMS.DAL.Repositories.Concrete;
using HMS.DAL.Services.Abstract;
using HMS.DAL.Services.Profiles;
using HMS.DTO;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Services.Concrete
{
    public class CountryService : Service<Country, CountryDto>, ICountryService
    {
        public CountryService(CountryRepo repo) : base(repo)
        {
            MapperConfiguration config = new MapperConfiguration(config =>
            {
                Profile profile = new CountryProfile();
                config.AddProfile(profile);
            });

            base.Mapper = config.CreateMapper();
        }

        public IEnumerable<CountryDto> GetActiveList()
        {
            IEnumerable<Country> countries = ((ICountryRepo)base._repo).GetActiveList();

            return _mapper.Map<IEnumerable<CountryDto>>(countries);
        }

    }
}
