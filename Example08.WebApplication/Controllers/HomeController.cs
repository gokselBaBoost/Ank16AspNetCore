using Example08.WebApplication.Filters;
using Example08.WebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Example08.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [CustomAuth]
        public IActionResult Index()
        {
            string queryString = HttpContext.Request.QueryString.Value;

            HttpContext.Response.Headers.Add("user-info","user Bilgisi");

            ViewBag.QueryString = queryString;

            return View();
        }

        [ApiKeyCheck]
        public IActionResult Privacy(string apiKey)
        {

            ViewBag.ApiKeyPrivacy = apiKey;

            for (int i = 0; i < int.MaxValue / 1000 ; i++)
            {
                Task.Delay(100);
            }

            return View();
        }

        public IActionResult ApiKeyNotFound()
        {
            ViewBag.ApiKeyNotFound = "Sistemi kullana bilmek adın url yapınızda ?api-key=xxxx-xxxx-xxxx-xxxx olacak şekilde göndermeniz gerekiyor.";
            return View();
        }

        public IActionResult ApiKeyNotMatched()
        {
            ViewBag.ApiKeyNotMatched = "Api Key uygun formatta değildir. ?apiKey=1234-ABCD-5678 olacak şekilde göndermeniz gerekiyor.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
