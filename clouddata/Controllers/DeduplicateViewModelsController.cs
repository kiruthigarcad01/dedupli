using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clouddata.Data;
using clouddata.Models;

namespace clouddata.Controllers
{
    public class DeduplicateViewModelsController : Controller
    {
        private readonly clouddataContext _context;

        public DeduplicateViewModelsController(clouddataContext context)
        {
            _context = context;
        }

        // GET: DeduplicateViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeduplicateViewModel.ToListAsync());
        }

        // GET: DeduplicateViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduplicateViewModel = await _context.DeduplicateViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deduplicateViewModel == null)
            {
                return NotFound();
            }

            return View(deduplicateViewModel);
        }

        // GET: DeduplicateViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeduplicateViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FileName,FilePath,FileHash,FileSize,UploadDate,IsDuplicate")] DeduplicateViewModel deduplicateViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deduplicateViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deduplicateViewModel);
        }

        // GET: DeduplicateViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduplicateViewModel = await _context.DeduplicateViewModel.FindAsync(id);
            if (deduplicateViewModel == null)
            {
                return NotFound();
            }
            return View(deduplicateViewModel);
        }

        // POST: DeduplicateViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FileName,FilePath,FileHash,FileSize,UploadDate,IsDuplicate")] DeduplicateViewModel deduplicateViewModel)
        {
            if (id != deduplicateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deduplicateViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeduplicateViewModelExists(deduplicateViewModel.Id))
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
            return View(deduplicateViewModel);
        }

        // GET: DeduplicateViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduplicateViewModel = await _context.DeduplicateViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deduplicateViewModel == null)
            {
                return NotFound();
            }

            return View(deduplicateViewModel);
        }

        // POST: DeduplicateViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deduplicateViewModel = await _context.DeduplicateViewModel.FindAsync(id);
            if (deduplicateViewModel != null)
            {
                _context.DeduplicateViewModel.Remove(deduplicateViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeduplicateViewModelExists(int id)
        {
            return _context.DeduplicateViewModel.Any(e => e.Id == id);
        }
    }
}
