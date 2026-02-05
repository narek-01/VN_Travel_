using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VN_Travel_.DAL;
using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Entities;
using VN_Travel_.Service.Interface;

namespace VN_Travel_.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        public AccountController(IUserService userService,ApplicationDbContext context,ICustomerService customerService)
        {
            _userService = userService;
            _context = context;
            _customerService = customerService;
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

        [HttpGet("Profile")]
        public IActionResult Profile(string email)
        {
            var customer = new Customer
            {
                   Email = email

            };
            return View(customer);
        }


        [HttpPost("Registration")]
        public IActionResult CreateUser(RegistratonDTO registrationDTO)
        {
            _userService.CreateUser(registrationDTO);
            return RedirectToAction("Profile" ,new { email = registrationDTO.Email });

            //return Ok();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveProfile(Customer customer)
        {

            // Проверяем валидность модели (аннотации в классе Customer)
            //if (!ModelState.IsValid)
            //{
            //    return View("Profile", customer);
            //}

            // 1. Ищем существующего пользователя в базе по Email
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == customer.Email);

            if (existingCustomer != null)
            {
                // 2. Обновляем поля
                existingCustomer.Name = customer.Name;
                existingCustomer.Surname = customer.Surname;
                existingCustomer.DateOfBirth = customer.DateOfBirth;
                existingCustomer.Nationality = customer.Nationality;
                existingCustomer.PassportId = customer.PassportId;
                existingCustomer.PassportExpiryDate = customer.PassportExpiryDate;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.Address = customer.Address;

                // 3. Сохраняем изменения
                _context.Customers.Update(existingCustomer);
                await _context.SaveChangesAsync();

                // Перенаправляем на страницу успеха или обратно в профиль с уведомлением
                TempData["SuccessMessage"] = "Профиль успешно обновлен!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var customerDTO = new CustomerDTO
                {
                    Name = customer.Name,
                    Surname = customer.Surname,
                    DateOfBirth = customer.DateOfBirth,
                    Nationality = customer.Nationality,
                    PassportId = customer.PassportId,
                    PassportExpiryDate = customer.PassportExpiryDate,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address,
                    CreatedAt = DateTime.Now,
                };
                _customerService.CreateCustomer(customerDTO);
                return RedirectToAction("Index", "Home");
            }

            //ModelState.AddModelError("", "Пользователь не найден.");
            //return View("Profile", customer);
        }

        // POST: /Account/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
