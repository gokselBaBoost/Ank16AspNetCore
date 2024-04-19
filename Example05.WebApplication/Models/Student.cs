using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Example05.WebApplication.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Adı")]
        public string Name { get; set; }

        [Display(Name = "Soyadı")]
        public string Surname { get; set; }

        [EmailAddress]
        [Display(Name = "E-Posta Adresi")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi")]
        public DateOnly BirthDate { get; set; }

        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }

        [Display(Name = "Öğrenci Durumu")]
        public StudentStatus StudentStatus { get; set; }
    }

    public enum Gender
    {
        [Display(Name = "Kadın")]
        Male,
        [Display(Name = "Erkek")]
        Female
    }

    public enum StudentStatus
    {
        [Display(Name = "Pasif")]
        Passive,
        [Display(Name = "Aktif")]
        Active,
        [Display(Name = "Dondurdu")]
        Frezee
    }
}
