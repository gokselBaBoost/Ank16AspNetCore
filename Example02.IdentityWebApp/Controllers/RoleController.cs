using Example02.IdentityWebApp.Data.Entities;
using Example02.IdentityWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Example02.IdentityWebApp.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<IdentityRole> roles = _roleManager.Roles.ToList();
            List<RoleViewModel> rolesViewModel = new List<RoleViewModel>();

            foreach (IdentityRole role in roles)
            {
                RoleViewModel roleViewModel = new RoleViewModel();
                roleViewModel.Name = role.Name;
                roleViewModel.RoleId = role.Id;

                rolesViewModel.Add(roleViewModel);
            }

            return View(rolesViewModel);
        }

        public IActionResult Add()
        {
            RoleViewModel model = new RoleViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(RoleViewModel model)
        {
            ModelState.Remove("RoleId");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IdentityRole role = new IdentityRole();
            role.Name = model.Name;

            IdentityResult result = _roleManager.CreateAsync(role).Result;

            if(!result.Succeeded)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult UserRoles(string id)
        {
            AppUser? user = _userManager.FindByIdAsync(id).Result;

            if (user == null)
            {
                return View("Error");
            }

            List<string> rolesToUser = _userManager.GetRolesAsync(user).Result.ToList();

            List<IdentityRole> roles =  _roleManager.Roles.ToList();


            ViewBag.NameSurname = $"{user.Name} {user.Surname} ({user.UserName})";
            ViewBag.Roles = roles;
            ViewBag.RolesToUser = rolesToUser;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRoleUpdate(string id, string roleId, bool status)
        {
            if(id.IsNullOrEmpty() || roleId.IsNullOrEmpty()) 
            {
                return BadRequest("Missing or Empty parameters");
            }

            IdentityRole? role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return NotFound("Role is not founded");
            }

            AppUser? user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound("User is not founded");
            }

            if (status)
                await _userManager.AddToRoleAsync(user, role.Name);
            else
                await _userManager.RemoveFromRoleAsync(user, role.Name);

            return Ok("The request has been done.");
        }
    }
}
