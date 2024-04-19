using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Practice01.WebApplication.Helpers
{
    public static class LoginFormHtmlHelper
    {
        public static IHtmlContent LoginForm(this IHtmlHelper htmlHelper)
        {
            HtmlContentBuilder builder = new HtmlContentBuilder();
            builder.AppendHtml(@"
                <div>
                    <input type='text' name='username' />
                    <input type='password' name='password' />
                    <input type='submit' value='Kaydet' />
                </div>
            ");

            return builder;
        }
    }
}
