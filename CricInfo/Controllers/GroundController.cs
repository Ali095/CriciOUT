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
    public class GroundController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroundController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ground
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ground.ToListAsync());
        }

        // GET: Ground/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ground = await _context.Ground
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ground == null)
            {
                return NotFound();
            }

            return View(ground);
        }

        [Authorize(Roles = "Admin")]
        // GET: Ground/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ground/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,contact,Availabity")] Ground ground)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ground);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ground);
        }

        // GET: Ground/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ground = await _context.Ground.SingleOrDefaultAsync(m => m.Id == id);
            if (ground == null)
            {
                return NotFound();
            }
            return View(ground);
        }

        // POST: Ground/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,contact,Availabity")] Ground ground)
        {
            if (id != ground.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ground);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroundExists(ground.Id))
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
            return View(ground);
        }

        // GET: Ground/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ground = await _context.Ground
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ground == null)
            {
                return NotFound();
            }

            return View(ground);
        }

        // POST: Ground/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ground = await _context.Ground.SingleOrDefaultAsync(m => m.Id == id);
            _context.Ground.Remove(ground);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroundExists(int id)
        {
            return _context.Ground.Any(e => e.Id == id);
        }
    }
}
