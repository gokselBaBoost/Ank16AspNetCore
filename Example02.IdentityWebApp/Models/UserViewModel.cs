using System.ComponentModel.DataAnnotations;

namespace Example02.IdentityWebApp.Models
{
    public class UserViewModel
    {
        public string UserId { get; set; }

        [Display(Name = "Kullaıcı Adı")]
        public string UserName { get; set; }

        [Display(Name = "Adı")]
        public string Name { get; set; }

        [Display(Name = "Soyadı")]
        public string Surname { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Display(Name = "Favori Takımınız")]
        public FavoriteTeam FavoriteTeam { get; set; }

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
