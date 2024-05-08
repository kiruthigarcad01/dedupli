using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myduplifree.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace myduplifree.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [Route("Home/Login")]
    public IActionResult Login()
    {
        return View();
    }
   
    [HttpPost]
[Route("Home/Login")]
public IActionResult Login(LoginViewModel loginModel)
{
    if (ModelState.IsValid)
    {
        if (loginModel.Username != null && loginModel.Password != null)
        {
            _logger.LogInformation(loginModel.Username + " " + loginModel.Password);

            var user = DbContext.Users.FirstOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);

            if (user != null)
            {
                if (loginModel.Username == "Admin")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Username or password is null.");
        }
    }
    else
    {
        return View(loginModel);
    }

    return View(loginModel);
}

//     private bool IsUserAuthenticated(string username, string password)
// {
//     // Implement your authentication logic here
//     // For demonstration purposes, let's assume a simple hardcoded check
//     if (username == "admin" && password == "password")
//     {
//         return true; // Authentication successful
//     }
//     else
//     {
//         return false; // Authentication failed
//     }
// }

    public IActionResult Register()
    {
        return View();
    }
       public IActionResult Users()
    {
        return View();
    }
   public IActionResult Dataholder()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
