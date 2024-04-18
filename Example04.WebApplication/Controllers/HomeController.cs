using Example04.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example04.WebApplication.Controllers
{
    //[Route("Public/{controller}/")]
    public class HomeController : Controller
    {
        //[Route("")]
        //[Route("Index")] /Home/Index/5
        public IActionResult Index(int id)
        {
            ViewBag.Menuler = GetMenus();
            ViewBag.AltMenuler = GetSubMenus();

            if (id == 0)
                id = 600;

            ViewBag.Baslik = id + " What is Lorem Ipsum?";
            ViewBag.Icerik = id + " Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            //ViewBag.Resim = "https://picsum.photos/200/300";
            ViewBag.Resim = $"/image/{id}-200x300.jpg";

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

            Menu menu1 = new Menu() { Id = 1, DisplayName = "Duyurular", Controller = "Home", Action = "Duyuru" };
            Menu menu2 = new Menu() { Id = 2, DisplayName = "Ürünler", Controller = "Home", Action = "Urunler" };
            Menu menu3 = new Menu() { Id = 3, DisplayName = "Makaleler", Controller = "Home", Action = "Makaleler" };

            menus.Add(menu1);
            menus.Add(menu2);
            menus.Add(menu3);

            return menus;
        }
    }
}
