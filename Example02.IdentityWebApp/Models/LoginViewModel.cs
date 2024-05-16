using System.ComponentModel.DataAnnotations;

namespace Example02.IdentityWebApp.Models
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
