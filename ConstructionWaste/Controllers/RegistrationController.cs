using System.Threading.Tasks;
using AutoMapper;
using ConstructionWaste.DTOs.Registration;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionWaste.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper _mapper;

        public RegistrationController(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            _mapper = mapper;
           
        }
        public IActionResult UserRegistration()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UserRegistration(RegistrerUserDTO model)
        {

            
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<AppUser>(model);
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");

                    return RedirectToAction("Login","Auth");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
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
