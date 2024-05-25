using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseProject.Data;
using DatabaseProject.Models;

namespace DatabaseProject.Controllers
{
    public class DataDeduplicationsController : Controller
    {
        private readonly DatabaseProjectContext _context;

        public DataDeduplicationsController(DatabaseProjectContext context)
        {
            _context = context;
        }

        // GET: DataDeduplications
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataDeduplication.ToListAsync());
        }

        // GET: DataDeduplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataDeduplications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] DataDeduplication dataDeduplication)
        {
            if (ModelState.IsValid)
            {
                // Check if the provided data already exists
                var existingData = await _context.DataDeduplication
                    .FirstOrDefaultAsync(m => m.Name == dataDeduplication.Name && m.Email == dataDeduplication.Email);

                if (existingData != null)
                {
                    // If data already exists, redirect to FindDuplicates action
                    return RedirectToAction(nameof(FindDuplicates));
                }

                // If data doesn't exist, proceed with creation
                _context.Add(dataDeduplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataDeduplication);
        }

        // GET: DataDeduplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataDeduplication = await _context.DataDeduplication.FindAsync(id);
            if (dataDeduplication == null)
            {
                return NotFound();
            }
            return View(dataDeduplication);
        }

        // POST: DataDeduplications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] DataDeduplication dataDeduplication)
        {
            if (id != dataDeduplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataDeduplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataDeduplicationExists(dataDeduplication.Id))
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
            return View(dataDeduplication);
        }

        // GET: DataDeduplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataDeduplication = await _context.DataDeduplication
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataDeduplication == null)
            {
                return NotFound();
            }

            return View(dataDeduplication);
        }

        // POST: DataDeduplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataDeduplication = await _context.DataDeduplication.FindAsync(id);
            _context.DataDeduplication.Remove(dataDeduplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> FindDuplicates()
        {
            var duplicates = await _context.DataDeduplication
                .FromSqlRaw(@"
                    SELECT *
                    FROM DataDeduplication p
                    WHERE EXISTS (
                        SELECT 1
                        FROM DataDeduplication p2
                        WHERE p2.Name = p.Name AND p2.Email = p.Email
                        GROUP BY p2.Name, p2.Email
                        HAVING COUNT(*) > 1
                    );
                ")
                .ToListAsync();

            return View(duplicates);
        }

        private bool DataDeduplicationExists(int? id)
        {
            if (id == null)
            {
                return false; // Return false if the id is null
            }
            return _context.DataDeduplication.Any(e => e.Id == id);
        }

    }
}
