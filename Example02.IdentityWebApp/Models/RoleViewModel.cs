using System.ComponentModel.DataAnnotations;

namespace Example02.IdentityWebApp.Models
{
    public class RoleViewModel
    {
        public string RoleId { get; set; }

        [Display(Name = "Role Adı")]
        public string Name { get; set; }

    }
}
