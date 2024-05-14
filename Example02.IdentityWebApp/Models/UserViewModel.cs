using System.ComponentModel.DataAnnotations;

namespace Example02.IdentityWebApp.Models
{
    public class UserViewModel
    {
        [Display(Name = "Kullaıcı Adı")]
        public string UserName { get; set; }

        [EmailAddress]
        [Display(Name = "E-Posta Adresi")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifre ile Şifre Tekrarı aynı değildir.")]
        [Display(Name = "Şifre Tekrarı")]
        public string ConfirmPassword { get; set; }
    }
}
