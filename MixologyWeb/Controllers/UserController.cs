using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MixologyWeb.Core.Constants;
using System.Reflection;

namespace MixologyWeb.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = UserConstants.Roles.Administrator)]
        //public async Task<IActionResult> ManageUsers() 
        //{
            
        //}

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
