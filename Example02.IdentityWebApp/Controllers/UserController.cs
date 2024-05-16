using Example02.IdentityWebApp.Data;
using Example02.IdentityWebApp.Data.Entities;
using Example02.IdentityWebApp.Helpers;
using Example02.IdentityWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Example02.IdentityWebApp.Controllers
{
    public class UserController : Controller
    {
        private AppDbContext _dbContext;
        private UserManager<AppUser> _userManager;

        public UserController(AppDbContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //PartialView().ExecuteResult(_controllerContext);

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


            //var users = _userManager;
            var users = _userManager.Users.ToList();

            //AppUser userCheck = _dbContext.AppUsers.Where(u => u.Email == "admin@mail.com").SingleOrDefault();  //FindByNameAsync(model.UserName).Result; // Email e bakıyor

            //if(userCheck != null)
            //{
            //    ViewBag.Error = "Kullanıcı Adı daha önceden kullanılmıştır";

            //    ModelState.AddModelError("UserName", "Kullanıcı Adı daha önceden kullanılıyor.");

            //    return View(model);
            //}

            //User Kayıt işlemleri yapılacaktır.

            AppUser user = new AppUser();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.BirthDate = model.BirthDate;
            user.FavoriteTeam = model.FavoriteTeam;
            //user.PasswordHash = Sifreleme.Md5Hash(model.Password); //Password Hash size ait olan bir hash provider ile çözümleye bilirsiniz.

            //_dbContext.Users.Add(user);
            //_dbContext.SaveChanges();


            //var result = await _userManager.CreateAsync(user);
            //Task<IdentityResult> result = _userManager.CreateAsync(user);

            IdentityResult result = _userManager.CreateAsync(user,model.Password).Result;

            //Eğer kayıt başarılı ise Index sayfasına geri döncektir.
            if(result.Succeeded)
            {
                //Mail Gönderimi yapılır
                string token = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;

                //MailSend(model.Email, model.);

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
