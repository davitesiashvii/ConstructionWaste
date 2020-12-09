  using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DAL.Models;
using System.Threading.Tasks;
using ConstructionWaste.DTOs.User;
using System.Linq;
using System.Collections.Generic;
using ConstructionWaste.DTOs.Registration;
using Microsoft.AspNetCore.Authorization;

namespace ConstructionWaste.Controllers.AdminControllers
{
    [Authorize(Roles ="admin")]
    public class UserServiceController : Controller
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;

        public UserServiceController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Users()
        {
            return View(_userManager.Users);
        }

        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegistrerUserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Users));
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);

        }
       


        public async Task<IActionResult> EditUser(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                EditUserDTO model = new EditUserDTO();
                model.Id = user.Id;
                model.Email = user.Email;
                model.Roles = _roleManager.Roles.Select(x => x.Name).ToList();
                model.UserRoles = (List<string>)await _userManager.GetRolesAsync(user);
                return View(model);
            }
            else
            {
                return RedirectToAction("Users");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserDTO model)
        {
            AppUser user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.Email = model.Email;
                IdentityResult result = await _userManager.UpdateAsync(user);
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    if (model.UserRoles == null ||
                        (model.UserRoles != null && !model.UserRoles.Contains(role)))
                    {
                        await _userManager.RemoveFromRoleAsync(user, role);
                    }
                }
                if (model.UserRoles != null)
                {
                    foreach (var role in model.UserRoles)
                    {
                        if (!roles.Contains(role))
                        {
                            await _userManager.AddToRoleAsync(user, role);
                        }
                    }
                }
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Users));
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Users));
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Users", _userManager.Users);
        }

        public IActionResult Roles()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Roles));
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(name);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

    }
}
