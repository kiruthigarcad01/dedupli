using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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

public IActionResult CloudFiles()
{
    // Assuming you have logic to retrieve cloud files from your database
    List<cloudfilesViewModel> cloudFiles = GetcloudfilesFromDatabase();

    // Pass the cloud files data to the view
    return View(cloudFiles);
}

        private List<cloudfilesViewModel> GetcloudfilesFromDatabase()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
[Route("Home/cloudfiles")]

public IActionResult cloudfiles(cloudfilesViewModel cloudfilesModel)
{
    if (ModelState.IsValid)
    {
        var cloudfiles = new cloudfilesViewModel
        {
            FileName = cloudfilesModel.FileName,
            FileLocation = cloudfilesModel. FileLocation,
            Publickey = cloudfilesModel.Publickey,
            Updatedto = cloudfilesModel.Updatedto,
            Youarein =cloudfilesModel. Youarein,
           
        };

        _context.cloudfiles.Add(cloudfiles);
        _context.SaveChanges();

        // Assuming you want to redirect to the login page after successful registration
        return RedirectToAction("Dataholder", "Home");
    }
   else
{
    // If model state is not valid, return the same view without passing a model
    return View();
}
}




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    }
}


