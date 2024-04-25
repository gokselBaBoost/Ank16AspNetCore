using Microsoft.AspNetCore.Mvc;
using System.Text;
using Mvc = System.Web.Mvc;

namespace Practice01.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ContentResult Index()
        {
            string html = @"<html>
            <head>
                <title>Başlık</title>
                <link rel=""stylesheet"" href=""/Home/IndexCss"" />
            </head>
            <body>
                <p>Bu yazı hem türkçe hem de content css tarafından Kırımız renktedir.</p>
                <button onclick=""TiklaBeni()"">Tıkla Beni</button>
                <button onclick=""BenYeni()"">Ben Yeni</button>
                <script type=""text/javascript"" src=""/Home/IndexJs""></script>
                <script type=""text/javascript"" src=""/Home/JsResult""></script>
            </body>
            </html>
            ";


            return Content(html, "text/html",Encoding.UTF8);
        }

        public ContentResult IndexCss()
        {
            return Content("p{color:red;}", "text/css", Encoding.UTF8);
        }

        public ContentResult IndexJs()
        {
            string jstext = @"
            function TiklaBeni(){
                alert(""Beni Tıkladın :)"");
            }
            ";

            return Content(jstext, "text/javascript", Encoding.UTF8);
        }

        public Mvc.JavaScriptResult JsResult()
        {
            return new Mvc.JavaScriptResult() { Script = @"function BenYeni(){alert(""Ben Yeni"");}" };
        }
    }
}
