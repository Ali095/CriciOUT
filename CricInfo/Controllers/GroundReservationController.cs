using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CricInfo.Data;
using CricInfo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CricInfo.Controllers
{
    public class GroundReservationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GroundReservationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: GroundReservation
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);


            var applicationDbContext = _context.GroundReservation.Where(x => x.UserId == user.Id).Include(g => g.GroundRef).Include(g => g.UserRef);
            //var applicationDbContext = _context.GroundReservation
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GroundReservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groundReservation = await _context.GroundReservation
                .Include(g => g.GroundRef)
                .Include(g => g.UserRef)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (groundReservation == null)
            {
                return NotFound();
            }

            return View(groundReservation);
        }

        // GET: GroundReservation/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name");
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: GroundReservation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,GroundId,ReservationDate")] GroundReservation groundReservation)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            groundReservation.UserId = user.Id;
            if (ModelState.IsValid)
            {
                if (groundReservation.ReservationDate == DateTime.Now.Date)
                {
                    ModelState.AddModelError("ReservationDate", "Today's Booking cannot be done! please select another date");
                }
                if (groundReservation.ReservationDate < DateTime.Now.Date)
                {
                    ModelState.AddModelError("ReservationDate", "You have Entered a Back Date Entry which is not Allowed");
                }
                var x = _context.GroundReservation.Where(xx => xx.ReservationDate == groundReservation.ReservationDate && xx.GroundId==groundReservation.GroundId ).Any();
                if (x == true)
                {
                    ModelState.AddModelError("ReservationDate", "This Date is already booked!");
                    ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name", groundReservation.GroundId);
                    return View(groundReservation);
                }
                _context.Add(groundReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name", groundReservation.GroundId);
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", groundReservation.UserId);
            return View(groundReservation);
        }

        // GET: GroundReservation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groundReservation = await _context.GroundReservation.SingleOrDefaultAsync(m => m.Id == id);
            if (groundReservation == null)
            {
                return NotFound();
            }
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Address", groundReservation.GroundId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", groundReservation.UserId);
            return View(groundReservation);
        }

        // POST: GroundReservation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,GroundId,ReservationDate")] GroundReservation groundReservation)
        {
            if (id != groundReservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groundReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroundReservationExists(groundReservation.Id))
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
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Address", groundReservation.GroundId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", groundReservation.UserId);
            return View(groundReservation);
        }

        // GET: GroundReservation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groundReservation = await _context.GroundReservation
                .Include(g => g.GroundRef)
                .Include(g => g.UserRef)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (groundReservation == null)
            {
                return NotFound();
            }

            return View(groundReservation);
        }

        // POST: GroundReservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groundReservation = await _context.GroundReservation.SingleOrDefaultAsync(m => m.Id == id);
            _context.GroundReservation.Remove(groundReservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroundReservationExists(int id)
        {
            return _context.GroundReservation.Any(e => e.Id == id);
        }

        public IActionResult CheckGroundAvailability()
        {
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name");
            return View("CheckGroundAvailability");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckGroundAvailability([Bind("GroundId,ReservationDate")] GroundReservation groundReservation)
        {
            if (ModelState.IsValid)
            {
                if (groundReservation.ReservationDate <= DateTime.Now.Date)
                {
                    ModelState.AddModelError("ReservationDate", "You have Entered a Back Date Entry which is not Allowed");
                }
                var x = _context.GroundReservation.Where(xx => xx.ReservationDate == groundReservation.ReservationDate && xx.GroundId == groundReservation.GroundId).Any();
                if (x == true)
                {
                    ModelState.AddModelError("ReservationDate", "This Ground is already booked on Selected Date!");
                }
                else
                {
                    ModelState.AddModelError("ReservationDate", "The Ground is Available for Booking on selected Date");
                }
                

            }
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name", groundReservation.GroundId);
            return View(groundReservation);
        }
    }
}
