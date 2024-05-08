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
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuDto, Menu>().ForMember(dest => dest.SubMenu, opt => opt.MapFrom(src => src.SubMenu));
            CreateMap<MenuDto, Menu>().ForMember(dest => dest.Menus, opt => opt.MapFrom(src => src.Menus));

            CreateMap<Menu, MenuDto>().ForMember(dest => dest.SubMenu, opt => opt.MapFrom(src => src.SubMenu));
            CreateMap<Menu, MenuDto>().ForMember(dest => dest.Menus, opt => opt.MapFrom(src => src.Menus));
        }
    }
}
