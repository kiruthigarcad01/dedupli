using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myduplifree.Data;
using myduplifree.Models; // Make sure to include your UploadfileViewModel namespace

namespace myduplifree.Controllers
{
    public class UploadfileController : Controller
    {
        private readonly AppDbContext _context;

        public UploadfileController(AppDbContext context)
        {
            _context = context;
        }

       [HttpGet]
    [Route("Uploadfile/Uploadfile")]
    public ActionResult UploadFile()
    {
    return View();
    }

        [HttpPost]
        [Route("Uploadfile/Uploadfile")]
        public IActionResult Uploadfile(UploadfileViewModel UploadfileModel)
        {
            if (ModelState.IsValid)
            {
                var Uploadfiledb = new UploadfileViewModel
                {
                    FileName = UploadfileModel.FileName,
                    Size = UploadfileModel.Size,
                    Format = UploadfileModel.Format,
                    StoragePath = UploadfileModel.StoragePath,
                };

                _context.Uploadfile.Add(Uploadfiledb);
                _context.SaveChanges();

                return RedirectToAction("Success"); // Redirect to some action after successful upload
            }
            else
            {
                return View(UploadfileModel);
            }
        }
    }
}
