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
    public class CityService : Service<City, CityDto>
    {
        public CityService(CityRepo repo) : base(repo)
        {
            base._profile = new CityProfile();
        }

        public override IEnumerable<CityDto> GetAll()
        {
            IEnumerable<City> cities =  base._repo.GetAll();

            List<CityDto> citiesDto = new List<CityDto>();

            foreach (City city in cities)
            {
                Country country = city.Country;

                CountryDto countryDto = new CountryDto();
                countryDto.Id = country.Id;
                countryDto.Name = country.Name;
                countryDto.UserId = country.UserId;
                countryDto.IsActive = country.IsActive;

                CityDto cityDto = new CityDto();
                cityDto.Name = city.Name;
                cityDto.IsActive = city.IsActive;
                cityDto.UserId = cityDto.UserId;
                cityDto.CountryId = cityDto.CountryId;

                cityDto.Country = countryDto;

                citiesDto.Add(cityDto);
            }


            return citiesDto;
        }
    }
}
