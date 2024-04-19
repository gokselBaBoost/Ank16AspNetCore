using Example05.WebApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Example05.WebApplication.CustomTagHelpers
{
    [HtmlTargetElement("ana-menu")]
    public class MenuTagHelper : TagHelper
    {
        public List<Menu> Items { get; set; }

        /*
         * 
         *  <nav class="navbar navbar-expand-lg bg-body-tertiary">
                 <div class="container-fluid">
                     <a class="navbar-brand" href="#">Navbar</a>
                     <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                         <span class="navbar-toggler-icon"></span>
                     </button>
                     <div class="collapse navbar-collapse" id="navbarNav">
                         <ul class="navbar-nav">
                             @foreach(Menu menu in ViewBag.Menuler)
                             {
                                 <li class="nav-item">
                                     <a asp-controller="@menu.Controller" 
                                        asp-action="@menu.Action" 
                                        class="nav-link @(ViewBag.Title == menu.DisplayName ? "active" : "")">
                                        @menu.DisplayName</a>
                                 </li>
                     
                             }
                         </ul>
                     </div>
                 </div>
             </nav>
         * 
         */


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //<nav> oluşturuldu.
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "nav";
            output.Attributes.Add("class", "navbar navbar-expand-lg bg-body-tertiary");

            //div.container
            TagBuilder divContainer = new TagBuilder("div");
            divContainer.Attributes.Add("class", "container-fluid");

            //a.navbar-brand
            TagBuilder aNavbarBrand = new TagBuilder("a");
            aNavbarBrand.Attributes.Add("class", "navbar-brand");
            aNavbarBrand.Attributes.Add("href", "#");
            aNavbarBrand.InnerHtml.Append("Navbar");

            //button.navbar-toggler
            TagBuilder buttonNavBarToggler = new TagBuilder("button");
            buttonNavBarToggler.Attributes.Add("type", "button");
            buttonNavBarToggler.Attributes.Add("class", "navbar-toggler");

            buttonNavBarToggler.Attributes.Add("data-bs-toggle", "collapse");
            buttonNavBarToggler.Attributes.Add("data-bs-target", "#navbarNav");
            buttonNavBarToggler.Attributes.Add("aria-controls", "navbarNav");
            buttonNavBarToggler.Attributes.Add("aria-expanded", "false");
            buttonNavBarToggler.Attributes.Add("aria-label", "Toggle navigation");

            //span.navbar-toggler-icon
            TagBuilder spanNavBarTogglerIcon = new TagBuilder("span");
            spanNavBarTogglerIcon.Attributes.Add("class", "navbar-toggler-icon");

            //div.collapse navbar-collapse
            TagBuilder divNavbarCollapse = new TagBuilder("div");
            divNavbarCollapse.Attributes.Add("id", "navbarNav");
            divNavbarCollapse.Attributes.Add("class", "collapse navbar-collapse");

            //ul.navbar-nav
            TagBuilder ulNavbarNav = new TagBuilder("ul");
            ulNavbarNav.Attributes.Add("class", "navbar-nav");

            foreach (Menu menu in Items)
            {
                TagBuilder liNavItem = new TagBuilder("li");
                liNavItem.Attributes.Add("class", "nav-item");

                TagBuilder aNavLink = new TagBuilder("a");
                aNavLink.Attributes.Add("class", "nav-link");

                //string href = "/" + menu.Controller + "/" + menu.Action;
                string href = menu.ToString();
                aNavLink.Attributes.Add("href", href);
                aNavLink.InnerHtml.Append(menu.DisplayName);

                liNavItem.InnerHtml.AppendHtml(aNavLink);

                ulNavbarNav.InnerHtml.AppendHtml(liNavItem);
            }

            divNavbarCollapse.InnerHtml.AppendHtml(ulNavbarNav);

            buttonNavBarToggler.InnerHtml.AppendHtml(spanNavBarTogglerIcon);

            divContainer.InnerHtml.AppendHtml(aNavbarBrand);
            divContainer.InnerHtml.AppendHtml(buttonNavBarToggler);
            divContainer.InnerHtml.AppendHtml(divNavbarCollapse);

            output.Content.AppendHtml(divContainer);
        }

    }
}
