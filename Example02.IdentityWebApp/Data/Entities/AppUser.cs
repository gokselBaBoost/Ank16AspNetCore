using Example02.IdentityWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace Example02.IdentityWebApp.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }
        public FavoriteTeam FavoriteTeam { get; set; }
    }
}
