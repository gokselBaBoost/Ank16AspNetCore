using AutoMapper;
using HMS.DTO;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Services.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryDto, Country>().ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities));
            CreateMap<Country, CountryDto>().ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities));

            CreateMap<CityDto, City>().ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
            CreateMap<City, CityDto>().ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
        }
    }
}
