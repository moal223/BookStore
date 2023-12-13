using BookStore.Services;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public RoleController(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager, IUserService userService,
            IRoleService roleService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userService = userService;
            _roleService = roleService;
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole roleModel = new IdentityRole();
                roleModel.Name = roleViewModel.RoleName;
                // Add to db
                IdentityResult result = await _roleManager.CreateAsync(roleModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("AddUserRole");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(roleViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> AddUserRole()
        {
            ViewData["Users"] = (await _userService.GetAllUsersAsync()).Select(user => user.UserName);
            ViewData["Roles"] = (await _roleService.GetAllRolesAsync()).Select(role => role.Name);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserRole(UserRoleViewModel userRole)
        {
            if (userRole.UserName != "" || userRole.RoleName != "")
            {
                // username, rolename
                if (ModelState.IsValid)
                {
                    //get usermodel
                    IdentityUser userModel = await _userManager.FindByNameAsync(userRole.UserName);
                    IdentityResult result = await _userManager.AddToRoleAsync(userModel, userRole.RoleName);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
                ModelState.AddModelError(string.Empty, "Please Choose User And Role");
            ViewData["Users"] = (await _userService.GetAllUsersAsync()).Select(user => user.UserName);
            ViewData["Roles"] = (await _roleService.GetAllRolesAsync()).Select(role => role.Name);
            return View(userRole);
        }
    }
}
