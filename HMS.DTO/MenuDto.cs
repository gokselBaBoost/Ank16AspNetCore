using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DTO
{
    public class MenuDto : BaseDto
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public int ParentId { get; set; }
        public MenuDto SubMenu { get; set; }

        public ICollection<MenuDto> Menus { get; set; }
    }
}
