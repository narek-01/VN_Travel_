using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VN_Travel_.Models;
using VN_Travel_.DAL;

namespace VN_Travel_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() => View();

        // Страницы (пока возвращают пустые списки или просто View)
        public IActionResult Countries() => View();

        public IActionResult Hotels() => View();

        public IActionResult Tours() => View();

        ////////////////////////////////////////////////////
        
        public IActionResult CountryDetails(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);
            
            // Пока что создадим "заглушку" (временные данные) для примера:
            ViewBag.CountryId = id;
            return View();
        }
        ////////////////////////////////////////////////////
        

        ////////////////////////////////////////////////////
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





    }
}
