using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example04.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Sonuç");
        }
    }
}
