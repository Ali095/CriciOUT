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

        [Authorize(Roles ="Admin")]
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
        public async Task<IActionResult> Create([Bind("Id,Name,Address,contact,Availabity,Location")] Ground ground)
        {
            if (ModelState.IsValid)
            {
                //ground.Location = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3324.5794752334814!2d73.08140601468567!3d33.56430075073355!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x38df93326d8b392b%3A0x37caff05aea67b2c!2sAyub+Park+Cricket+Ground!5e0!3m2!1sen!2s!4v1563389464647!5m2!1sen!2s";
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
