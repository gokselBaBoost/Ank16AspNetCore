using Example04.IdentityCustomWebApp.Data.Entities;
using Example04.IdentityCustomWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Example04.IdentityCustomWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            AppUser userCheck = await _userManager.FindByNameAsync("Kgk");


            AppUser user = new AppUser();
            user.Name = "Göksel";
            user.Surname = "Kalyoncu";
            user.UserName = "Kgk1";
            user.Email = "gokse@mail.com";

            IdentityResult result = await _userManager.CreateAsync(user, "Az*123456");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
