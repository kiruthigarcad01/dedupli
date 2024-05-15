using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kgc.Models;
using kgc.Data;
using Microsoft.EntityFrameworkCore;

namespace kgc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
     private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context) 
    {
        _logger = logger;
        _context = context;
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

   [HttpGet]
    [Route("Home/cloudfiles")]
    public IActionResult cloudfiles()
    {
    return View();
    }

    [HttpPost]
[Route("Home/cloudfiles")]
public async Task<IActionResult> cloudfiles(cloudfilesViewModel cloudfiles)
{
    if (ModelState.IsValid)
    {
        try
        {
            var cloudfiletype = new cloudfilesViewModel
            {
                // Assuming Id is the primary key
                // You should remove Id assignment if it's an auto-generated or identity column
                // Id = Guid.NewGuid(), // Generate a new unique Id
                Username = cloudfiles.Username,
                Email = cloudfiles.Email,
                PhoneNumber = cloudfiles.PhoneNumber,
                CSP = cloudfiles.CSP,
                Generate_Keys = cloudfiles.Generate_Keys
            };

            _context.cloudfiles.Add(cloudfiletype);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Dataholder record has been added to the table");

            return RedirectToAction("KGC", "Home");
        }
        catch (DbUpdateException ex)
        {
            // Log the exception
            _logger.LogError(ex, "An error occurred while saving the entity changes.");

            // Handle the exception gracefully, e.g., show a user-friendly error message
            ModelState.AddModelError(string.Empty, "An error occurred while saving the data. Please try again.");

            return View("Register", "Home", cloudfiles);
        }
    }
    else
    {
        // Model validation failed, return the view with validation errors
        return View("Register", "Home", cloudfiles);
    }
}

    private IActionResult View(string v1, string v2, cloudfilesViewModel cloudfiles)
    {
        throw new NotImplementedException();
    }

    public IActionResult KGC()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
