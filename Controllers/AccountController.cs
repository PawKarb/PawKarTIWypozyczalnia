using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PawKarTIWypozyczalnia.Models;
using PawKarTIWypozyczalnia.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace PawKarTIWypozyczalnia.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> userManager { get; }
        SignInManager<AppUser> signInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user) 
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                };
                var result = await userManager.CreateAsync(newUser, newUser.Password);
                var errorList = result.Errors.ToList();
                ViewBag.Result = string.Join("\n\r",errorList.Select(e=>e.Description));
            }
            
            return View(user);
        }

        [HttpGet]
        public IActionResult Register() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(user.Login, user.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    ModelState.AddModelError("", "Nieudana próba logowania");
                }
                return View();
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login() { return View(); }
    }
}
