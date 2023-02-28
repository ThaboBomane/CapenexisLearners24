using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapenexisLeaners24.Data;
using CapenexisLearners24.Models;

namespace CapenexisLeaners24.Controllers
{
    public class FacilitatorsController : Controller
    {
        private readonly CapenexisLeaners24Context _context;

        public FacilitatorsController(CapenexisLeaners24Context context)
        {
            _context = context;
        }

        // GET: Facilitators
        public async Task<IActionResult> Index()
        {
              return _context.Facilitators != null ? 
                          View(await _context.Facilitators.ToListAsync()) :
                          Problem("Entity set 'CapenexisLeaners24Context.Facilitators'  is null.");
        }

        // GET: Facilitators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Facilitators == null)
            {
                return NotFound();
            }

            var facilitators = await _context.Facilitators
                .FirstOrDefaultAsync(m => m.FacilitatorsId == id);
            if (facilitators == null)
            {
                return NotFound();
            }

            return View(facilitators);
        }

        // GET: Facilitators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facilitators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacilitatorsId,FacilitatorsName,FacilitatorsSurname")] Facilitators facilitators)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facilitators);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facilitators);
        }

        // GET: Facilitators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Facilitators == null)
            {
                return NotFound();
            }

            var facilitators = await _context.Facilitators.FindAsync(id);
            if (facilitators == null)
            {
                return NotFound();
            }
            return View(facilitators);
        }

        // POST: Facilitators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacilitatorsId,FacilitatorsName,FacilitatorsSurname")] Facilitators facilitators)
        {
            if (id != facilitators.FacilitatorsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facilitators);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilitatorsExists(facilitators.FacilitatorsId))
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
            return View(facilitators);
        }

        // GET: Facilitators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Facilitators == null)
            {
                return NotFound();
            }

            var facilitators = await _context.Facilitators
                .FirstOrDefaultAsync(m => m.FacilitatorsId == id);
            if (facilitators == null)
            {
                return NotFound();
            }

            return View(facilitators);
        }

        // POST: Facilitators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Facilitators == null)
            {
                return Problem("Entity set 'CapenexisLeaners24Context.Facilitators'  is null.");
            }
            var facilitators = await _context.Facilitators.FindAsync(id);
            if (facilitators != null)
            {
                _context.Facilitators.Remove(facilitators);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilitatorsExists(int id)
        {
          return (_context.Facilitators?.Any(e => e.FacilitatorsId == id)).GetValueOrDefault();
        }
    }
}
