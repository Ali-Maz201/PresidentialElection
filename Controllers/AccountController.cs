using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresidentialElection.Data;
using PresidentialElection.ViewModels;
using System.Threading.Tasks;

namespace PresidentialElection.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<StoreUser> _userManager;
        private readonly SignInManager<StoreUser> _signInManager;
        private readonly IMapper _mapper;
        

        public AccountController(UserManager<StoreUser> userManager, SignInManager<StoreUser> signInManager, IMapper mapper, ApplicationContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {   
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<RegisterViewModel, StoreUser>(model);
                
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {   
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Register Attempt");

            }
            return View(model);
        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl))
                    {

                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

              ModelState.AddModelError("", "Username or password is incorrect");

            }
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
