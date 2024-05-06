using AutoMapper;
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
        public CityService( CityRepo repo ) : base(repo)
        {
            MapperConfiguration config = new MapperConfiguration(config =>
            {
                Profile profile = new CityProfile();
                config.AddProfile(profile);
            });

            base.Mapper = config.CreateMapper();
        }
    }
}
