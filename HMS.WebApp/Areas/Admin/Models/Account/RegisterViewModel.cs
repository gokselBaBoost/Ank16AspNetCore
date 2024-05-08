using System.ComponentModel.DataAnnotations;

namespace HMS.WebApp.Areas.Admin.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        [MaxLength(20, ErrorMessage = "Lütfen 50 den büyük uzunlukta bir isim girmeyiniz")]
        [MinLength(3, ErrorMessage = "Lütfen 3 den küçük uzunlukta bir isim girmeyiniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadı giriniz.")]
        [MaxLength(20, ErrorMessage = "Lütfen 50 den büyük uzunlukta bir isim girmeyiniz")]
        [MinLength(3, ErrorMessage = "Lütfen 3 den küçük uzunlukta bir isim girmeyiniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen email giriniz.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,10}$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,10}$")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler aynı değil")]
        public string ConfirmPassword { get; set; }
        public bool IsAgreeTerms { get; set; }
    }
}
