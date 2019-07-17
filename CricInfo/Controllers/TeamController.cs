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
using Microsoft.AspNetCore.Identity;

namespace CricInfo.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeamController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Team
        public async Task<IActionResult> Index()
        {
            return View(await _context.Team.ToListAsync());
        }

        // GET: Team/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .SingleOrDefaultAsync(m => m.Id == id);
            var players = _context.Players.Where(m => m.TeamId == team.Id).ToList();
            ViewBag.play = players;
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Team/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Name,Captain,Players")] Team team)
        {
            //var user = _userManager.GetCurrentUser(HttpContext);
            var user = await _userManager.GetUserAsync(User);
            team.Owner = user.Id;
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                var p1 = HttpContext.Request.Form["p1"];
                var p2 = HttpContext.Request.Form["p2"];
                var p3 = HttpContext.Request.Form["p3"];
                var p4 = HttpContext.Request.Form["p4"];
                var p5 = HttpContext.Request.Form["p5"];
                var p6 = HttpContext.Request.Form["p6"];
                var p7 = HttpContext.Request.Form["p7"];
                var p8 = HttpContext.Request.Form["p8"];
                var p9 = HttpContext.Request.Form["p9"];
                var p10 = HttpContext.Request.Form["p10"];
                var p11 = HttpContext.Request.Form["p11"];
                var p12 = HttpContext.Request.Form["p12"];
                var p13 = HttpContext.Request.Form["p13"];
                var p14 = HttpContext.Request.Form["p14"];
                var p15 = HttpContext.Request.Form["p15"];

                int pa1 = int.Parse(HttpContext.Request.Form["pa1"]);
                var pa2 = int.Parse(HttpContext.Request.Form["pa2"]);
                var pa3 = int.Parse(HttpContext.Request.Form["pa3"]);
                var pa4 = int.Parse(HttpContext.Request.Form["pa4"]);
                var pa5 = int.Parse(HttpContext.Request.Form["pa5"]);
                var pa6 = int.Parse(HttpContext.Request.Form["pa6"]);
                var pa7 = int.Parse(HttpContext.Request.Form["pa7"]);
                var pa8 = int.Parse(HttpContext.Request.Form["pa8"]);
                var pa9 = int.Parse(HttpContext.Request.Form["pa9"]);
                var pa10 = int.Parse(HttpContext.Request.Form["pa10"]);
                var pa11 = int.Parse(HttpContext.Request.Form["pa11"]);
                var pa12 = int.Parse(HttpContext.Request.Form["pa12"]);
                var pa13 = int.Parse(HttpContext.Request.Form["pa13"]);
                var pa14 = int.Parse(HttpContext.Request.Form["pa14"]);
                var pa15 = int.Parse(HttpContext.Request.Form["pa15"]);

                var ps1 = int.Parse(HttpContext.Request.Form["ps1"]);
                var ps2 = int.Parse(HttpContext.Request.Form["ps2"]);
                var ps3 = int.Parse(HttpContext.Request.Form["ps3"]);
                var ps4 = int.Parse(HttpContext.Request.Form["ps4"]);
                var ps5 = int.Parse(HttpContext.Request.Form["ps5"]);
                var ps6 = int.Parse(HttpContext.Request.Form["ps6"]);
                var ps7 = int.Parse(HttpContext.Request.Form["ps7"]);
                var ps8 = int.Parse(HttpContext.Request.Form["ps8"]);
                var ps9 = int.Parse(HttpContext.Request.Form["ps9"]);
                var ps10 = int.Parse(HttpContext.Request.Form["ps10"]);
                var ps11 = int.Parse(HttpContext.Request.Form["ps11"]);
                var ps12 = int.Parse(HttpContext.Request.Form["ps12"]);
                var ps13 = int.Parse(HttpContext.Request.Form["ps13"]);
                var ps14 = int.Parse(HttpContext.Request.Form["ps14"]);
                var ps15 = int.Parse(HttpContext.Request.Form["ps15"]);


                Player pl1 = new Player
                {
                    Name = p1,
                    Age = pa1,
                    ShirtNumber = ps1,
                    TeamId = team.Id
                };

                Player pl2 = new Player
                {
                    Name = p2,
                    Age = pa2,
                    ShirtNumber = ps2,
                    TeamId = team.Id
                };
                Player pl3 = new Player
                {
                    Name = p3,
                    Age = pa3,
                    ShirtNumber = ps3,
                    TeamId = team.Id
                };
                Player pl4 = new Player
                {
                    Name = p4,
                    Age = pa4,
                    ShirtNumber = ps4,
                    TeamId = team.Id
                };
                Player pl5 = new Player
                {
                    Name = p5,
                    Age = pa5,
                    ShirtNumber = ps5,
                    TeamId = team.Id
                };
                Player pl6 = new Player
                {
                    Name = p6,
                    Age = pa6,
                    ShirtNumber = ps6,
                    TeamId = team.Id
                };
                Player pl7 = new Player
                {
                    Name = p7,
                    Age = pa7,
                    ShirtNumber = ps7,
                    TeamId = team.Id
                };
                Player pl8 = new Player
                {
                    Name = p8,
                    Age = pa8,
                    ShirtNumber = ps8,
                    TeamId = team.Id
                };
                Player pl9 = new Player
                {
                    Name = p9,
                    Age = pa9,
                    ShirtNumber = ps9,
                    TeamId = team.Id
                };
                Player pl10 = new Player
                {
                    Name = p10,
                    Age = pa10,
                    ShirtNumber = ps10,
                    TeamId = team.Id
                };
                Player pl11 = new Player
                {
                    Name = p11,
                    Age = pa11,
                    ShirtNumber = ps11,
                    TeamId = team.Id
                };
                Player pl12 = new Player
                {
                    Name = p12,
                    Age = pa12,
                    ShirtNumber = ps12,
                    TeamId = team.Id
                };
                Player pl13= new Player
                {
                    Name = p13,
                    Age = pa13,
                    ShirtNumber = ps13,
                    TeamId = team.Id
                };
                Player pl14 = new Player
                {
                    Name = p14,
                    Age = pa14,
                    ShirtNumber = ps14,
                    TeamId = team.Id
                };
                Player pl15 = new Player
                {
                    Name = p15,
                    Age = pa15,
                    ShirtNumber = ps15,
                    TeamId = team.Id
                };
                
                _context.Players.Add(pl1); _context.Add(pl2); _context.Add(pl3); _context.Add(pl4); _context.Add(pl5);
                _context.Add(pl6); _context.Add(pl7); _context.Add(pl8); _context.Add(pl9); _context.Add(pl10);
                _context.Add(pl11); _context.Add(pl12); _context.Add(pl13); _context.Add(pl14);
                _context.Add(pl15);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Team/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.SingleOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Captain,MatchPlayed,MatchWin,MatchLoose,MatchTie")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
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
            return View(team);
        }

        // GET: Team/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .SingleOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Team.SingleOrDefaultAsync(m => m.Id == id);
            _context.Team.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.Id == id);
        }
    }
}
