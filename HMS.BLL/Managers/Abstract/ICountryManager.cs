using HMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Managers.Abstract
{
    public interface ICountryManager
    {
        IEnumerable<CountryDto> GetActiveList();
    }
}
