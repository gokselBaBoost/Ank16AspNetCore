using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Example04.WebApplication.Models
{
    public class Contact
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }

        [BindNever]
        public string Mesaj { get; set; }
    }
}
