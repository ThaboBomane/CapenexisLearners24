﻿using System;
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
    public class LearnersController : Controller
    {
        private readonly CapenexisLeaners24Context _context;

        public LearnersController(CapenexisLeaners24Context context)
        {
            _context = context;
        }

        // GET: Learners
        public async Task<IActionResult> Index()
        {
              return _context.Learners != null ? 
                          View(await _context.Learners.ToListAsync()) :
                          Problem("Entity set 'CapenexisLeaners24Context.Learners'  is null.");
        }

        // GET: Learners/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Learners == null)
            {
                return NotFound();
            }

            var learners = await _context.Learners
                .FirstOrDefaultAsync(m => m.LearnersId == id);
            if (learners == null)
            {
                return NotFound();
            }

            return View(learners);
        }

        // GET: Learners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Learners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LearnersId,LearnersName,LearnersSurname,LearnersIdentityNumber")] Learners learners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learners);
        }

        // GET: Learners/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Learners == null)
            {
                return NotFound();
            }

            var learners = await _context.Learners.FindAsync(id);
            if (learners == null)
            {
                return NotFound();
            }
            return View(learners);
        }

        // POST: Learners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("LearnersId,LearnersName,LearnersSurname,LearnersIdentityNumber")] Learners learners)
        {
            if (id != learners.LearnersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnersExists(learners.LearnersId))
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
            return View(learners);
        }

        // GET: Learners/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Learners == null)
            {
                return NotFound();
            }

            var learners = await _context.Learners
                .FirstOrDefaultAsync(m => m.LearnersId == id);
            if (learners == null)
            {
                return NotFound();
            }

            return View(learners);
        }

        // POST: Learners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Learners == null)
            {
                return Problem("Entity set 'CapenexisLeaners24Context.Learners'  is null.");
            }
            var learners = await _context.Learners.FindAsync(id);
            if (learners != null)
            {
                _context.Learners.Remove(learners);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearnersExists(long id)
        {
          return (_context.Learners?.Any(e => e.LearnersId == id)).GetValueOrDefault();
        }
    }
}
