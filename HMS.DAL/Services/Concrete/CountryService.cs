using HMS.DAL.Context;
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
    public class CountryService : Service<Country, CountryDto>, ICountryService
    {
        public CountryService(CountryRepo repo) : base(repo)
        {}

        public IEnumerable<CountryDto> GetActiveList()
        {
            IEnumerable<Country> countries = ((ICountryRepo)base._repo).GetActiveList();

            List<CountryDto> countriesDto = new List<CountryDto>();

            foreach (Country country in countries)
            { 
                CountryDto countryDto = new CountryDto();

                countryDto.Id = country.Id;
                countryDto.Name = country.Name;
                countryDto.UserId = country.UserId;
                countryDto.IsActive = country.IsActive;

                countriesDto.Add(countryDto);
            }

            //return _mapper.Map<IEnumerable<CountryDto>>(countries);

            return countriesDto;
        }

        public override IEnumerable<CountryDto> GetAll()
        {
            IEnumerable<Country> countries = base._repo.GetAll();

            List<CountryDto> countriesDto = new List<CountryDto>();

            foreach (Country country in countries)
            {

                CountryDto countryDto = new CountryDto();
                countryDto.Id = country.Id;
                countryDto.Name = country.Name;
                countryDto.UserId = country.UserId;
                countryDto.IsActive = country.IsActive;

                countriesDto.Add(countryDto);
            }


            return countriesDto;
        }
    }
}
