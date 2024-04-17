using Example03.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example03.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kayit()
        {
            var postForm = HttpContext.Request.Form;
            var getForm = HttpContext.Request.Form;

            var postQueryString = HttpContext.Request.Query;
            var getQueryString = HttpContext.Request.Query;

            return View();
        }

        public IActionResult Kayit2()
        {
            //var postForm = HttpContext.Request.Form;
            //var getForm = HttpContext.Request.Form;

            var postQueryString = HttpContext.Request.Query;
            var getQueryString = HttpContext.Request.Query;

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            //return View("Iletisim");

            ContactForm form = new ContactForm();

            return View("IletisimTagHelper", form);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Contact(ContactForm form)
        {
            bool isValid = ModelState.IsValid;

            //Bir işlem yapılacak veri tabanına kayıt ve benzeri aksiyonlar alınır.

            //1. Aynı Controller da başka bir actiona yönlendirme yapabiliriz.

            //2. Farklı Controller da bir actiona yönlendirme yapabiliriz.

            //3. Aynı aciton için aynı view e geri dönebiliriz.

            //string mesaj = $"{ad} {soyad} mesajınız ilgili birime ulaşmıştır. Teşekkür ederiz";

            //return View(model: mesaj);
            //return View("Iletisim", mesaj);
            //return View("IletisimTagHelper", mesaj);

            return RedirectToAction("Index");
        }
    }
}
