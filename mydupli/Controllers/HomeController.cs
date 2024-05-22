using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mydupli.Data;
using mydupli.Models;
using System.Threading.Tasks;

namespace mydupli.Controllers
{
    public class KGCvaluesController : Controller
    {
        private readonly AppDbContext _context;

        public KGCvaluesController(AppDbContext context)
        {
            _context = context;
        }

    
     [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        // GET: KGCvalues
        public async Task<IActionResult> Index()
        {
            return View(await _context.KGCvalues.ToListAsync());
        }

        // GET: KGCvalues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KGCvalues/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,FileName,Size,Format,StoragePath")] KGCvaluesViewModel kgCvaluesViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kgCvaluesViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kgCvaluesViewModel);
        }

        // GET: KGCvalues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kgCvaluesViewModel = await _context.KGCvalues.FindAsync(id);
            if (kgCvaluesViewModel == null)
            {
                return NotFound();
            }
            return View(kgCvaluesViewModel);
        }

        // POST: KGCvalues/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,FileName,Size,Format,StoragePath")] KGCvaluesViewModel kgCvaluesViewModel)
        {
            if (id != kgCvaluesViewModel.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kgCvaluesViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KGCvaluesViewModelExists(kgCvaluesViewModel.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kgCvaluesViewModel);
        }

        private bool KGCvaluesViewModelExists(int? userID)
        {
            throw new NotImplementedException();
        }

        // GET: KGCvalues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kgCvaluesViewModel = await _context.KGCvalues
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (kgCvaluesViewModel == null)
            {
                return NotFound();
            }

            return View(kgCvaluesViewModel);
        }

        // POST: KGCvalues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kgCvaluesViewModel = await _context.KGCvalues.FindAsync(id);
            // _context.KGCvalues.Remove(kgCvaluesViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KGCvaluesViewModelExists(int id)
        {
            return _context.KGCvalues.Any(e => e.UserID == id);
        }
    }
}
