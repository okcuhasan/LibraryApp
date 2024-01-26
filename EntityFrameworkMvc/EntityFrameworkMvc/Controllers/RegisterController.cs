using EntityFrameworkMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMvc.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Name, Password = model.Password,Role = model.Role }; 

                var result = await _userManager.CreateAsync(user, model.Password); 

                if (result.Succeeded)
                {
                    if(model.Role == null)
                    {
                        return BadRequest("Invalid role");
                    }
                    else if (model.Role == "Admin" || model.Role == "User")
                    {
                        await _userManager.AddToRoleAsync(user, model.Role);

                        return View();
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

    }
}
