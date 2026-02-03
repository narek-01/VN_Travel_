using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VN_Travel_.Controllers
{
    public class AccountController : Controller
    {
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

        // POST: /Account/Logout
         [HttpPost]
         public async Task<IActionResult> Logout()
         {
            return RedirectToAction("Index", "Home");
         }
    }
}
