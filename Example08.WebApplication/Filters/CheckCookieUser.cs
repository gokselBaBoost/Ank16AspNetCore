using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Example08.WebApplication.Filters
{
    public class CheckCookieUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Controller controller = context.Controller as Controller;

            var controllerValues = controller.RouteData.Values;

            if(controllerValues["controller"].ToString() != "Account")
            {

                if (context.HttpContext.Request.Cookies.ContainsKey("user"))
                {
                    if (context.HttpContext.Request.Cookies["user"] == "admin")
                    {
                        controller.ViewBag.IsAdmin = true;
                    }
                    else
                    {
                        controller.ViewBag.IsAdmin = false;
                    }
                }
                else
                {
                    RedirectResult result = new RedirectResult("/Account/Login");
                    context.Result = result;
                }
            }            
        }
    }
}
