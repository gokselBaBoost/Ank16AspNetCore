using Microsoft.AspNetCore.Mvc;

namespace HMS.WebApp.Controllers
{
    public class HotelController : Controller
    {
        [Route("oteller")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("oteller/sehir/{id:int:length(4):min(1000):max(5000)}")]
        public string GetByCity(int id)
        {
            int sonuc = id / 0;

            return $"{id} li oteller buraya AJAX ile geldi.";
        }
    }
}
