using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HMS.WebApp.Models
{
    public class CityAddViewModel
    {
        [Required(ErrorMessage = "Bu alanı girilmesi zorunludur.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Şehir Adı için lütfen en az 3 en fazla 25 karakterli değer giriniz.")]
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        [Range(1, byte.MaxValue, ErrorMessage = "Lütfen geçerli bir ülke seçiniz.")]
        public int CountryId { get; set; }

        [ValidateNever]
        [BindNever]
        public CountryEditListViewModel Country { get; set; }
    }
}
