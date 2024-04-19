using Example05.WebApplication.Models;

namespace Example05.WebApplication.Services
{
    public class MenuService
    {
        public List<Menu> GetMenus()
        {
            List<Menu> menus = new List<Menu>();

            Menu menu1 = new Menu() { Id = 1, DisplayName = "Anasayfa", Controller = "Home", Action = "Index" };
            Menu menu2 = new Menu() { Id = 2, DisplayName = "Öğrenciler", Controller = "Student", Action = "Index" };
            Menu menu3 = new Menu() { Id = 3, DisplayName = "Öğretmenler", Controller = "Teacher", Action = "Index" };
            Menu menu4 = new Menu() { Id = 4, DisplayName = "Dersler", Controller = "Lesson", Action = "Index" };

            menus.Add(menu1);
            menus.Add(menu2);
            menus.Add(menu3);
            menus.Add(menu4);

            return menus;
        }
    }
}
