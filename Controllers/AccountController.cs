using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace ASP.NETCoreMVCByLaxmiBhattarai.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
                                 UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username,string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password,isPersistent:false,lockoutOnFailure:false);

            if (result.Succeeded) {

                 return RedirectToAction("Index", "Student");

            }

            //return Json(new
            //{
            //    Success = false,
            //    Message = "Invalid Login"
            //});
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string email,string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };

            var result = await _userManager.CreateAsync(user,password);

            if (result.Succeeded) {

                return RedirectToAction("Login", "Account");
            
            }

            foreach (var error in result.Errors) { 
                ModelState.AddModelError(string.Empty, error.Description);
            
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("", "");
        }
    }
}
