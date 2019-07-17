using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CricInfo.Data;
using CricInfo.Models;
using Microsoft.AspNetCore.Authorization;

namespace CricInfo.Controllers
{
    public class UmpireController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UmpireController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Umpire
        public async Task<IActionResult> Index()
        {
            return View(await _context.Umpire.ToListAsync());
        }

        // GET: Umpire/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var umpire = await _context.Umpire
                .SingleOrDefaultAsync(m => m.Id == id);
            if (umpire == null)
            {
                return NotFound();
            }

            return View(umpire);
        }

        [Authorize(Roles ="Admin")]
        // GET: Umpire/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Umpire/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Contact,Experience,ProExperience,Availability")] Umpire umpire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(umpire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(umpire);
        }

        [Authorize(Roles ="Admin")]
        // GET: Umpire/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var umpire = await _context.Umpire.SingleOrDefaultAsync(m => m.Id == id);
            if (umpire == null)
            {
                return NotFound();
            }
            return View(umpire);
        }

        [Authorize(Roles = "Admin")]
        // POST: Umpire/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Contact,Experience,ProExperience,Availability")] Umpire umpire)
        {
            if (id != umpire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(umpire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UmpireExists(umpire.Id))
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
            return View(umpire);
        }
        [Authorize(Roles = "Admin")]
        // GET: Umpire/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var umpire = await _context.Umpire
                .SingleOrDefaultAsync(m => m.Id == id);
            if (umpire == null)
            {
                return NotFound();
            }

            return View(umpire);
        }

        // POST: Umpire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var umpire = await _context.Umpire.SingleOrDefaultAsync(m => m.Id == id);
            _context.Umpire.Remove(umpire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UmpireExists(int id)
        {
            return _context.Umpire.Any(e => e.Id == id);
        }
    }
}
