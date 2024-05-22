using Example02.WebAppToApi.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System.Diagnostics;

namespace Example02.WebAppToApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://www.bilgeadam.com/");
            //httpClient.BaseAddress = new Uri("https://www.google.com/");

            HttpResponseMessage responseMessage = await httpClient.GetAsync("urunler/fowcrm");

            var htmlContent = await responseMessage.Content.ReadAsStringAsync();

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlContent);

            var xPath = "/html/body/div[3]/div/div/div/div/div[2]/div[1]/div/div[6]";

            var nodes = htmlDocument.DocumentNode.SelectNodes(xPath);


            HtmlRead htmlRead = new HtmlRead();
            //htmlRead.InnerHtml = nodes[0].InnerHtml;
            htmlRead.InnerHtml = htmlContent;

            return View(htmlRead);
        }

        public async Task<IActionResult> Privacy()
        {
            Service1Client service1Client = new Service1Client();

            string result = await service1Client.GetDataAsync(15);

            CompositeType compositeType = new CompositeType();
            compositeType.BoolValue = true;
            compositeType.StringValue = "Merhaba Dünya ";

            CompositeType? result2 = await service1Client.GetDataUsingDataContractAsync(compositeType);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
