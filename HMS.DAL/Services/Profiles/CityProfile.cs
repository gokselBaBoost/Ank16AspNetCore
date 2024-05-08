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
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityDto, City>().ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
            CreateMap<CityDto, City>().ForMember(dest => dest.AccountUser, opt => opt.MapFrom(src => src.AccountUser));


            CreateMap<City, CityDto>().ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
            CreateMap<City, CityDto>().ForMember(dest => dest.AccountUser, opt => opt.MapFrom(src => src.AccountUser));

            CreateMap<CountryDto, Country>().ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities));
            CreateMap<Country, CountryDto>().ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities));

            CreateMap<AccountUserDto, AccountUser>().ReverseMap();
        }
    }
}
