using System.Diagnostics;
using kGC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using myduplifree.Data;
using myduplifree.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace myduplifree.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

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
                var logindb = new LoginViewModel
                {
                    Username = loginModel.Username,
                    Password = loginModel.Password,
                };

                _context.login.Add(logindb);
                _context.SaveChanges();

                return View("Dataholder", "Home");
            }
            else
            {
                return View(loginModel);
            }
        }


        [HttpGet]
        [Route("Home/Register")]
        public IActionResult Register()
        {
            return View();
        }


[HttpPost]
[Route("Home/Register")]
public IActionResult Register(RegisterViewModel RegisterModel)
{
    if (ModelState.IsValid)
    {
        var Register = new RegisterViewModel
        {
            FullName = RegisterModel.FullName,
            Username = RegisterModel.Username,
            Email = RegisterModel.Email,
            PhoneNumber = RegisterModel.PhoneNumber,
            Password = RegisterModel.Password,
            // Gender = RegisterModel.Gender, // Assuming you have Gender property in RegisterViewModel
        };

        _context.Register.Add(Register);
        _context.SaveChanges();

        // Assuming you want to redirect to the login page after successful registration
        return RedirectToAction("Login", "Home");
    }
    else
    {
        // If model state is not valid, return the same view with validation errors
        return View(RegisterModel);
    }
}

 

[HttpGet]
[Route("Home/DataHolder")]
   public IActionResult Dataholder()
    {
        return View();
    }

    [HttpPost]
[Route("Home/Dataholder")]
public IActionResult Create(DataholderViewModel DataholderModel)
{
    if (ModelState.IsValid)
    {
        var Dataholder = new DataholderViewModel
        {
            Name = DataholderModel.Name,
	        Rownumber = DataholderModel.Rownumber,
            // Add other properties as needed
        };

        _context.Dataholder.Add(Dataholder);
        _context.SaveChanges();

        return RedirectToAction("Login", "Home"); 
    }
    else
    {
        return View(DataholderModel);
    }
}

[HttpGet]
        [Route("Home/cloudfiles")]
        public IActionResult Cloudfiles()
        {
            return View();
        }

        [HttpPost]
        [Route("Home/cloudfiles")]
        public async Task<IActionResult> Cloudfiles(cloudfilesViewModel cloudfiles)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cloudfiletype = new cloudfilesViewModel
                    {
                        Username = cloudfiles.Username,
                        Email = cloudfiles.Email,
                        PhoneNumber = cloudfiles.PhoneNumber,
                        CSP = cloudfiles.CSP,
                        Generate_Keys = cloudfiles.Generate_Keys
                    };

                    _context.cloudfiles.Add(cloudfiletype);
                    await _context.SaveChangesAsync();

                    ILogger.LogInformation("Dataholder record has been added to the table");

                    return RedirectToAction("KGC", "Home");
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "An error occurred while saving the entity changes.");
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the data. Please try again.");

                    // Corrected the method call to use proper view and controller names
                    return RedirectToAction("Register", "Home", cloudfiles);
                }
            }
            else
            {
                return View("Register");
            }
        }

        [HttpGet]
        [Route("Home/KGC")]
        public IActionResult KGC()
        {
            return View();
        }

        [HttpPost]
        [Route("Home/KGC")]
        public async Task<IActionResult> KGC(KGCViewModel KGC)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var KGCtype = new KGCViewModel
                    {
                        FileName = KGC.FileName,
                        FileLocation = KGC.FileLocation,
                        Publickey = KGC.Publickey,
                        Updatedto = KGC.Updatedto,
                        Youarein = KGC.Youarein
                    };

                    _context.KGC.Add(KGCtype);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Dataholder record has been opened");

                    return RedirectToAction("KGC");
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "An error occurred while saving the entity changes.");
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the data. Please try again.");

                    // Corrected the method call to use proper view and controller names
                    return RedirectToAction("KGC");
                }
            }
            else
            {
                return View("Register");
            }
        }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    }
}


