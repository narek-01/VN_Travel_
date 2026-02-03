using Microsoft.AspNetCore.Mvc;
using VN_Travel_.Service.Interface;

namespace VN_Travel_.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }
}
