using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Core.Constants;
using ShoppingListApp.Core.Models.Account;
using ShoppingListApp.Infrastructure.Data.Identity;

namespace ShoppingListApp.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;       

        public AccountController(
            UserManager<ApplicationUser> _userManager, 
            SignInManager<ApplicationUser> _signInManager
            )
        {
            userManager = _userManager;
            signInManager = _signInManager;
           
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel();

            return View(model); 
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                TempData[MessageConstants.SuccessMessage] = "You have successfully log in!";
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName                
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {                
                await signInManager.SignInAsync(user, isPersistent: false);
                await userManager.AddToRoleAsync(user, "Customer");
                await signInManager.SignOutAsync();
                await signInManager.SignInAsync(user, isPersistent: false);
                TempData[MessageConstants.SuccessMessage] = "You have successfully become a new user!";

                return RedirectToAction("Index", "Home");
                //return RedirectToAction("Login", "Account");
                
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            TempData[MessageConstants.ErrorMessage] = "You have successfully log out!";

            return RedirectToAction("Index", "Home");
        }
    }
}
