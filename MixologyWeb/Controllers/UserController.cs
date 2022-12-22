using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MixologyWeb.Core.Constants;
using MixologyWeb.Core.Contracts;
using MixologyWeb.Core.Models;
using System.Reflection;

namespace MixologyWeb.Controllers
{
    [Authorize(Roles = UserConstants.Roles.Administrator)]
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserService userService;

        public UserController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<IdentityUser> _userManager,
            IUserService _userService
            )
        {
            roleManager = _roleManager;
            userManager = _userManager;
            userService= _userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ManageUsers()
        {
            var users = await userService.GetUsers();
            return View(users);
        }

        public async Task<IActionResult> Roles(string id) 
        {
            return Ok(id);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await userService.GetUserForEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, UserEditViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await userService.UpdateUser(model))
            {
                ViewData[MessageConstants.SuccessMessage] = "User Updated";
            }
            else
            {
                ViewData[MessageConstants.ErrorMessage] = "ERROR! User was NOT updated";
            }

            return View(model);
        }


        public async Task<IActionResult> CreateRole()
        {
            var roles = typeof(UserConstants.Roles).GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach (var role in roles)
            {
                string roleValue = role.GetValue(null).ToString() ?? string.Empty;

                bool roleExists = await roleManager.RoleExistsAsync(roleValue);

                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = roleValue
                    });
                }

            }

            return Ok();
        }
    }
}
