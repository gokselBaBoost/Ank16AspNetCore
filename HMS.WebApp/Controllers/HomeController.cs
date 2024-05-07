using HMS.WebApp.Models;
using HMS.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace HMS.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;

        public HomeController(ILogger<HomeController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            //_logger.LogInformation($" mailService Instance - Index : { _mailService.GetHashCode().ToString()}");

            ////GetOtherAction();

            //_mailService.Send("goksel@mail.com", "Services Örnegi", "Bu mesaj mail servisi ile gönderildi.--->");

            //List<SelectListItem> cars = new List<SelectListItem>();
            //cars.Add(new SelectListItem() { Text = "Mercedes", Value = "1" });
            //cars.Add(new SelectListItem() { Text = "BMW", Value = "2" });
            //cars.Add(new SelectListItem() { Text = "Volvo", Value = "3" });

            //ViewBag.Cars = cars;

            return View();
        }

        [ResponseCache(Duration = 10, VaryByHeader = "Time-To-Local")]
        public string CacheTime()
        {
            return DateTime.Now.ToString();
        }

        //private void GetOtherAction()
        //{
        //    _logger.LogInformation($" mailService Instance - GetOtherAction : {mailService.GetHashCode().ToString()}");
        //}

        public IActionResult Index2([FromServices] IMailService mailService)
        {
            _logger.LogInformation($" _mailService Instance  - Index 2 : {_mailService.GetHashCode().ToString()}");
            _logger.LogInformation($" mailService Instance  - Index 2 : {mailService.GetHashCode().ToString()}");

            List<SelectListItem> cars = new List<SelectListItem>();
            cars.Add(new SelectListItem() { Text = "Mercedes", Value = "1" });
            cars.Add(new SelectListItem() { Text = "BMW", Value = "2" });
            cars.Add(new SelectListItem() { Text = "Volvo", Value = "3" });

            ViewBag.Cars = cars;

            return View("Index");
        }

        public IActionResult Index3()
        {
            _logger.LogInformation($" mailService Instance  - Index 3 : {_mailService.GetHashCode().ToString()}");

            List<SelectListItem> cars = new List<SelectListItem>();
            cars.Add(new SelectListItem() { Text = "Mercedes", Value = "1" });
            cars.Add(new SelectListItem() { Text = "BMW", Value = "2" });
            cars.Add(new SelectListItem() { Text = "Volvo", Value = "3" });

            ViewBag.Cars = cars;

            return View("Index");
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
