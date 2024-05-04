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
            CreateMap<CountryDto, Country>()
                    .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities))
                    .ReverseMap();

            CreateMap<CityDto, City>()
                .ForMember(dest => dest.Country , opt => opt.MapFrom(src => src.Country))
                .ReverseMap();
        }
    }
}
