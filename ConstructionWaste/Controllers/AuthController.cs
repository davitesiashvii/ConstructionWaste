using System.Threading.Tasks;
using ConstructionWaste.DTOs.Auth;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ConstructionWaste.Controllers
{
    
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO details)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(user, details.Password, false, false);
                    var IsAdmin = await userManager.IsInRoleAsync(user, "admin");
                    var IsUser= await userManager.IsInRoleAsync(user, "user");
                    

                    if (result.Succeeded)
                    {
                       // RedirectToAction("Index", "student");
                        
                        if (IsAdmin)
                           return RedirectToAction("Index", "Home");
                        else if (IsUser)
                           return RedirectToAction("Privacy", "Home");

                    }
                    ModelState.AddModelError("", "Invalid user or password");
                }
                
            }
            return View(details);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }


        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
