using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DTO
{
    public class CityDto : BaseDto
    {
        public string Name { get; set; }
        public CountryDto Country { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }

    }
}
