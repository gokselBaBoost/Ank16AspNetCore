using HMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Services.Abstract
{
    public interface ICountryService
    {
        IEnumerable<CountryDto> GetActiveList();
    }
}
