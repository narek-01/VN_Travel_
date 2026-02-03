using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VN_Travel_.Service.Interface;
using VN_Travel_.DAL.DTOs;

namespace VN_Travel_.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Registration")]
        public IActionResult CreateUser(RegistratonDTO registrationDTO)
        {
            _userService.CreateUser(registrationDTO);
            RedirectToAction("Home/Index");

            return Ok();

        }

        // POST: /Account/Logout
        [HttpPost]
         public async Task<IActionResult> Logout()
         {
            return RedirectToAction("Index", "Home");
         }
    }
}
