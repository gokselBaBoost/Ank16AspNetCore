using Example05.WebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example05.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private const string _pageTitle = "Home";
        public IActionResult Index()
        {
            ViewBag.Title = $"{_pageTitle} Index";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = $"{_pageTitle} About";
            return View();
        }
    }
}
