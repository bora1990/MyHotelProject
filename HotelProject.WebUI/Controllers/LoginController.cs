using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LogInDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LogInUserDto logInUserDto)
        {
            if (ModelState.IsValid)
            {
                //IsPersistant kullanıcı tarayıcıyı kapatsa dahi oturum açık kalır.Başarısız oturum denemelerinde hesap kilitlenir.
                var result = await _signInManager.PasswordSignInAsync(logInUserDto.UserName, logInUserDto.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Staff");
                }

            }

            return View();
        }
    }
}
