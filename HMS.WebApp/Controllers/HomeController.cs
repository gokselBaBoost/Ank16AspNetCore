using HMS.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace HMS.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<SelectListItem> cars = new List<SelectListItem>();
            cars.Add(new SelectListItem() { Text = "Mercedes", Value = "1" });
            cars.Add(new SelectListItem() { Text = "BMW", Value = "2" });
            cars.Add(new SelectListItem() { Text = "Volvo", Value = "3" });

            ViewBag.Cars = cars;

            return View();
        }

        public IActionResult CarModels(int id)
        {
            List<SelectListItem> carModels = new List<SelectListItem>();

            switch (id)
            {
                case 1:
                    carModels.Add(new SelectListItem() { Text = "CL 200", Value = "1" });
                    carModels.Add(new SelectListItem() { Text = "E 200", Value = "2" });
                    carModels.Add(new SelectListItem() { Text = "GLK 200", Value = "3" });

                    break;
                case 2:

                    carModels.Add(new SelectListItem() { Text = "X 5", Value = "1" });
                    carModels.Add(new SelectListItem() { Text = "M 3", Value = "2" });
                    carModels.Add(new SelectListItem() { Text = "3.20", Value = "3" });

                    break;
                case 3:

                    carModels.Add(new SelectListItem() { Text = "XC 90", Value = "1" });
                    carModels.Add(new SelectListItem() { Text = "S 90", Value = "2" });
                    carModels.Add(new SelectListItem() { Text = "V 40", Value = "3" });

                    break;
                default:
                    break;
            }

            ViewBag.CarModels = carModels;

            return PartialView("_CarModels");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetHelloWorld()
        {
            return PartialView();//
        }

        public double Karesi(int sayi)
        {
            return Math.Pow(sayi,2);
        }

        public IActionResult Login(string username, string password)
        {
            if(username == null || password == null)
            {
                ViewBag.IsLogin = false;
            }
            else if (username == "admin" || password == "123456")
            {
                ViewBag.IsLogin = true;
                ViewBag.Username = username;
            }
            else
            {
                ViewBag.IsLogin = false;
            }

            return PartialView("_Login");
        }

        public IActionResult Color(string color)
        {
            ViewBag.Color = color;  
            return PartialView("_Color");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
