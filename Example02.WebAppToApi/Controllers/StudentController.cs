using Example02.WebAppToApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example02.WebAppToApi.Controllers
{
    public class StudentController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://localhost:7071/");

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("/Students");

            var students = httpResponseMessage.Content.ReadFromJsonAsync<List<StudentViewModel>>().Result;


            return View(students);
        }
    }
}
