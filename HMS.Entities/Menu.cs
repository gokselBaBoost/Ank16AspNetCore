using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public string? Url { get; set; }

        public string? Area { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Menu? SubMenu { get; set; }   

        public bool IsActive { get; set; }

        public virtual ICollection<Menu> Menus { get; set;}
    }
}
