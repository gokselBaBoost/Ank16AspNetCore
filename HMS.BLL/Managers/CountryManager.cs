using HMS.DAL.Context;
using HMS.DAL.Services.Concrete;
using HMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Managers
{
    public class CountryManager 
    {
        private CountryService _countryService;
        public CountryManager(HmsDbContext context)
        {
            _countryService = new CountryService(context);
        }
        public int Add(CountryDto dto)
        {
            //Session yönetimi ile alacağımız User bilgisi

            dto.UserId = new Random().Next(10,101);

            return _countryService.Add(dto);
        }

        public IEnumerable<CountryDto> GetAll()
        {
            return _countryService.GetAll();
        }
    }
}
