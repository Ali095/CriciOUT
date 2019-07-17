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
    public class MatchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Match
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Matches.Include(m => m.BatTeam).Include(m => m.BowlTeam).Include(m => m.GroundRef).Include(m => m.UmpireRef).Include(m => m.UmpireRef2);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Match/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.BatTeam)
                .Include(m => m.BowlTeam)
                .Include(m => m.GroundRef)
                .Include(m => m.UmpireRef)
                .Include(m => m.UmpireRef2)
                .SingleOrDefaultAsync(m => m.id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Match/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["TeamA"] = new SelectList(_context.Team, "Id", "Name");
            ViewData["TeamB"] = new SelectList(_context.Team, "Id", "Name");
            ViewData["Ground"] = new SelectList(_context.Ground, "Id", "Name");
            ViewData["Umpire1"] = new SelectList(_context.Umpire, "Id", "Name");
            ViewData["Umpire2"] = new SelectList(_context.Umpire, "Id", "Name");
            return View();
        }

        // POST: Match/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("id,Ground,TotalOvers,CurrentOver,CurrentScore,CurrentWickets,TeamA,TeamB,Result,Umpire1,Umpire2")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamA"] = new SelectList(_context.Team, "Id", "Name", match.TeamA);
            ViewData["TeamB"] = new SelectList(_context.Team, "Id", "Name", match.TeamB);
            ViewData["Ground"] = new SelectList(_context.Ground, "Id", "Name", match.Ground);
            ViewData["Umpire1"] = new SelectList(_context.Umpire, "Id", "Name", match.Umpire1);
            ViewData["Umpire2"] = new SelectList(_context.Umpire, "Id", "Name", match.Umpire2);
            return View(match);
        }

        // GET: Match/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.SingleOrDefaultAsync(m => m.id == id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["TeamA"] = new SelectList(_context.Team, "Id", "Name", match.TeamA);
            ViewData["TeamB"] = new SelectList(_context.Team, "Id", "Name", match.TeamB);
            ViewData["Ground"] = new SelectList(_context.Ground, "Id", "Name", match.Ground);
            ViewData["Umpire1"] = new SelectList(_context.Umpire, "Id", "Name", match.Umpire1);
            ViewData["Umpire2"] = new SelectList(_context.Umpire, "Id", "Name", match.Umpire2);
            return View(match);
        }

        // POST: Match/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("id,Ground,TotalOvers,CurrentOver,CurrentScore,CurrentWickets,TeamA,TeamB,Result,Umpire1,Umpire2")] Match match)
        {
            if (id != match.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.id))
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
            ViewData["TeamA"] = new SelectList(_context.Team, "Id", "Name", match.TeamA);
            ViewData["TeamB"] = new SelectList(_context.Team, "Id", "Name", match.TeamB);
            ViewData["Ground"] = new SelectList(_context.Ground, "Id", "Name", match.Ground);
            ViewData["Umpire1"] = new SelectList(_context.Umpire, "Id", "Name", match.Umpire1);
            ViewData["Umpire2"] = new SelectList(_context.Umpire, "Id", "Name", match.Umpire2);
            return View(match);
        }

        // GET: Match/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.BatTeam)
                .Include(m => m.BowlTeam)
                .Include(m => m.GroundRef)
                .Include(m => m.UmpireRef)
                .Include(m => m.UmpireRef2)
                .SingleOrDefaultAsync(m => m.id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Match/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Matches.SingleOrDefaultAsync(m => m.id == id);
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.id == id);
        }

        public async Task<IActionResult> ScoreCard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.SingleOrDefaultAsync(m => m.id == id);
            if (match == null)
            {
                return NotFound();
            }
            List<Player> PlayersList =_context.Players.Where(m => m.TeamId == match.TeamA).ToList();
            List<Player> PlayersListBowler = _context.Players.Where(m => m.TeamId == match.TeamB).ToList();

            ViewData["Striker"] = new SelectList(PlayersList, "Id", "Name");
            ViewData["NonStriker"] = new SelectList(PlayersList, "Id", "Name");
            ViewData["Bowler"] = new SelectList(PlayersListBowler, "Id", "Name");
            return View(match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ScoreCard(int id, Match match)
        {



            var RegisteredMatch = await _context.Matches.SingleOrDefaultAsync(m => m.id == id);
            if (RegisteredMatch == null)
            {
                return NotFound();
            }

            RegisteredMatch.Striker = match.Striker;

            if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(match);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MatchExists(match.id))
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
                ViewData["TeamA"] = new SelectList(_context.Team, "Id", "Name", match.TeamA);
                ViewData["TeamB"] = new SelectList(_context.Team, "Id", "Name", match.TeamB);
                ViewData["Ground"] = new SelectList(_context.Ground, "Id", "Name", match.Ground);
                ViewData["Umpire1"] = new SelectList(_context.Umpire, "Id", "Name", match.Umpire1);
                ViewData["Umpire2"] = new SelectList(_context.Umpire, "Id", "Name", match.Umpire2);
                return View(match);
        }

        public IActionResult ScoreCardDesign()
        {
            return View();
        }
    }
}
