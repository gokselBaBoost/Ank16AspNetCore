using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Security.Principal;

namespace HMS.WebApp.Areas.Admin.Filters
{
    public class UserInfoActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if( context.ActionDescriptor.RouteValues["area"] != null)
            {
                Controller controller = context.Controller as Controller;

                string name = "";
                string surname = "";
                string email = "";


                foreach(Claim claim in context.HttpContext.User.Claims)
                {
                    if(claim.Type == ClaimTypes.Name)
                    {
                        name = claim.Value;
                    }

                    if (claim.Type == ClaimTypes.Surname)
                    {
                        surname = claim.Value;
                    }

                    if (claim.Type == ClaimTypes.Email)
                    {
                        email = claim.Value;
                    }
                }

                controller.ViewBag.UserNameSurname = name + " " + surname + $"({email})";

            }

            base.OnActionExecuting(context);
        }
    }
}
