using Example02.IdentityWebApp.Data;
using Example02.IdentityWebApp.Helpers;
using Example02.IdentityWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Example02.IdentityWebApp.Controllers
{
    public class UserController : Controller
    {
        private AppDbContext _dbContext;
        private UserManager<IdentityUser> _userManager;
        private ControllerContext _controllerContext;

        public UserController(AppDbContext dbContext, UserManager<IdentityUser> userManager, ControllerContext context
            )
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _controllerContext = context;
        }

        public IActionResult Index()
        {
            PartialView().ExecuteResult(_controllerContext);

            return View();
        }

        public IActionResult Add()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(UserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            //User Kayıt işlemleri yapılacaktır.

            IdentityUser user = new IdentityUser();
            user.UserName = model.UserName;
            user.Email = model.Email;
            //user.PasswordHash = Sifreleme.Md5Hash(model.Password); //Password Hash size ait olan bir hash provider ile çözümleye bilirsiniz.

            //_dbContext.Users.Add(user);
            //_dbContext.SaveChanges();


            //var result = await _userManager.CreateAsync(user);
            //Task<IdentityResult> result = _userManager.CreateAsync(user);
            IdentityResult result = _userManager.CreateAsync(user,model.Password).Result;

            //Eğer kayıt başarılı ise Index sayfasına geri döncektir.
            if(result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }


            //Hatalı durumda hataları Model e ekleyerek geri dönceğiz
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return View(model);

        }
    }
}
