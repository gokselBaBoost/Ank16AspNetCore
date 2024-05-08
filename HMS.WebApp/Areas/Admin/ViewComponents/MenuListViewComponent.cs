using HMS.BLL.Managers.Concrete;
using HMS.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HMS.WebApp.Areas.Admin.ViewComponents
{
    public class MenuListViewComponent : ViewComponent
    {
        private MenuManager _menuManager;
        
        public MenuListViewComponent(MenuManager menuManager)
        {
            _menuManager = menuManager;
        }

        public IViewComponentResult Invoke()
        {
            List<MenuDto> menuDtos = _menuManager.GetAll().Where(m => m.ParentId == 0).ToList();


            return View(menuDtos);
        }
    }
}
