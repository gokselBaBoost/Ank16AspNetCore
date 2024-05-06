using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DTO
{
    public class CountryDto : BaseDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<CityDto> Cities { get; set; }
    }
}
