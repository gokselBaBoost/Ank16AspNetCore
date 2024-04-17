using System.ComponentModel.DataAnnotations;

namespace Example03.WebApplication.Models
{
    public class ContactForm
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int Age { get; set; }
        public bool IsStudent { get; set; }

        [EmailAddress]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [MinLength(6)]
        [MaxLength(12)]
        public string Password { get; set; }
    }
}
