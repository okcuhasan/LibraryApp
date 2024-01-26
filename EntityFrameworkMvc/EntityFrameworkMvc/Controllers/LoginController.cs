using EntityFrameworkMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Text.Json;

    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
            var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var roles = await _userManager.GetRolesAsync(user);

                string userModelJson = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("UserModel", userModelJson);

                return RedirectToAction("Index", "Home");
            }
                else
                {
                    return View();
                }
            }

            return View();
        }

    

}
