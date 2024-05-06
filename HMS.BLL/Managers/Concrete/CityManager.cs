using HMS.BLL.Managers.Abstract;
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
    public class CityManager : Manager<CityDto, City>
    {
        public CityManager(CityService service) : base(service)
        {}
    }
}
