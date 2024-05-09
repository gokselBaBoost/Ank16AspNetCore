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

        [Required(ErrorMessage = "Lütfen doğum tarihinizi giriniz")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; } = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#.?!@$%^&*-]).{8,}$", ErrorMessage = "Şifreniz en az 8 karakter en fazla 10 karakter olmalıdır. İçinde sayı ve karakter içermelidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen tekrar şifresini giriniz.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girdiğiniz şifreler aynı değil")]
        public string ConfirmPassword { get; set; }
        public bool IsAgreeTerms { get; set; }
    }
}
