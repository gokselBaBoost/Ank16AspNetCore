using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Example01.WebApplication.Fonksiyonlar
{
    public class Anasayfa
    {
        private HttpContext _httpContext;

        public Anasayfa(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public async Task HomePage()
        {
            string page = _httpContext.Request.Query["page"];
            string size = _httpContext.Request.Query["size"];

            string response = $"Anasayfaya hoş geldiniz Sayfa:{page} Boyut:{size}";

            await _httpContext.Response.WriteAsync(response);
        }

        public async Task AboutPage()
        {
            string response = $"Hakkımızda sayfasına hoş geldiniz";

            await _httpContext.Response.WriteAsync(response);
        }

        public async Task ContactPage()
        {
            string response = $"İletişim sayfasına hoş geldiniz";

            await _httpContext.Response.WriteAsync(response);
        }
    }
}
