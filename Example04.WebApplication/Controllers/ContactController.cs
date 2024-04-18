using Example04.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example04.WebApplication.Controllers
{
    //[Route("Admin/{controller}")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Menuler = GetMenus();
            ViewBag.AltMenuler = GetSubMenus();
            return View();
        }

        private List<Menu> GetMenus()
        {
            List<Menu> menus = new List<Menu>();

            Menu menu1 = new Menu() { Id = 1, DisplayName = "Anasayfa", Controller = "Home", Action = "Index" };
            Menu menu2 = new Menu() { Id = 2, DisplayName = "Hakkımızda", Controller = "About", Action = "Index" };
            Menu menu3 = new Menu() { Id = 3, DisplayName = "Projeler", Controller = "Project", Action = "Index" };
            Menu menu4 = new Menu() { Id = 4, DisplayName = "İletişim", Controller = "Contact", Action = "Index" };

            menus.Add(menu1);
            menus.Add(menu2);
            menus.Add(menu3);
            menus.Add(menu4);

            return menus;
        }

        private List<Menu> GetSubMenus()
        {
            List<Menu> menus = new List<Menu>();

            Menu menu1 = new Menu() { Id = 1, DisplayName = "Bize Ulaşın", Controller = "Contact", Action = "BizeUlasin" };
            Menu menu2 = new Menu() { Id = 2, DisplayName = "Şikayet Öneri", Controller = "Contact", Action = "SikayetOneri" };
            Menu menu3 = new Menu() { Id = 3, DisplayName = "İş Başvurusu", Controller = "Contact", Action = "IsBasvurusu" };

            menus.Add(menu1);
            menus.Add(menu2);
            menus.Add(menu3);

            return menus;
        }
    }
}
