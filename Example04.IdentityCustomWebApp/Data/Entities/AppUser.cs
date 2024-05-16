using Microsoft.AspNetCore.Identity;

namespace Example04.IdentityCustomWebApp.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
