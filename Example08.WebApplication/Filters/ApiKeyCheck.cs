using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Example08.WebApplication.Filters
{
    public class ApiKeyCheck : ActionFilterAttribute
    {
        private Stopwatch _stopwatch = new Stopwatch();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch.Start();

            var actionArguments = context.ActionArguments;
            string apiKey = "";

            if (actionArguments.Any())
            {
                apiKey = actionArguments["apiKey"].ToString();
                Regex regex = new Regex(@"^[0-9][0-9][0-9][0-9]-[A-Z][A-Z][A-Z][A-Z]-[0-9][0-9][0-9][0-9]$", RegexOptions.IgnoreCase);
                if (!regex.IsMatch(apiKey)) {

                    RedirectResult result = new RedirectResult("/Home/ApiKeyNotMatched");

                    context.Result = result;
                    context.HttpContext.Request.Headers.Add("api-key-status", "false");
                }
                else
                {
                    // Api Key benim db de var mı?

                    Controller controller = context.Controller as Controller;

                    controller.ViewBag.ApiKey = $"Beni ApiKey Check ekledi. {apiKey} [OnActionExecuting] ";
                    context.HttpContext.Request.Headers.Add("api-key-status", "true");

                    //base.OnActionExecuting(context);
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Controller controller = context.Controller as Controller;

            _stopwatch.Stop();
            controller.ViewBag.ApiKey += $" - Beni ApiKey Check ekledi. [OnActionExecuted] {_stopwatch.Elapsed.Seconds}";
            

            //base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _stopwatch.Restart();

            if (context.HttpContext.Request.Headers["api-key-status"] == "true")
            {
                ViewResult result = context.Result as ViewResult;
                result.ViewData["Time"] = "OnResultExecuting : " + DateTime.Now.ToString();
            }
            else
            {
                Console.WriteLine("[OnResultExecuting] : api-key-status false olduğu için işlem yapılmadı.");
            }

            //base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _stopwatch.Stop();
            if (context.HttpContext.Request.Headers["api-key-status"] == "true")
            {
                Console.WriteLine($"View başarıyla render edildi.{_stopwatch.Elapsed.Seconds}");
            }
            else
            {
                Console.WriteLine("[OnResultExecuted] : api-key-status false olduğu için işlem yapılmadı.");
            }

            //base.OnResultExecuted(context);
        }
    }
}
