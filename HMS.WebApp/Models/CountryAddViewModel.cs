using System.ComponentModel.DataAnnotations;

namespace HMS.WebApp.Models
{
    public class CountryAddViewModel
    {
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Lütfen Ülke adını en az 3 en fazla 25 karakterli giriniz.")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
