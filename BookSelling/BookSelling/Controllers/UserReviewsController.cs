 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookSelling.Data;
using BookSelling.Models;

namespace BookSelling.Controllers
{
    public class UserReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserReviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserReview.Include(u => u.Utilizador).Include(u => u.Utilizador2);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserReview == null)
            {
                return NotFound();
            }

            var userReview = await _context.UserReview
                .Include(u => u.Utilizador)
                .Include(u => u.Utilizador2)
                .FirstOrDefaultAsync(m => m.IdReview == id);
            if (userReview == null)
            {
                return NotFound();
            }

            return View(userReview);
        }

        // GET: UserReviews/Create
        public IActionResult Create()
        {
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "UserID", "Area");
            ViewData["Utilizador2FK"] = new SelectList(_context.Utilizadores, "UserID", "Area");
            return View();
        }

        // POST: UserReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReview,ValueReview,DateReview,UtilizadorFK,Utilizador2FK")] UserReview userReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "UserID", "Area", userReview.UtilizadorFK);
            ViewData["Utilizador2FK"] = new SelectList(_context.Utilizadores, "UserID", "Area", userReview.Utilizador2FK);
            return View(userReview);
        }

        // GET: UserReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserReview == null)
            {
                return NotFound();
            }

            var userReview = await _context.UserReview.FindAsync(id);
            if (userReview == null)
            {
                return NotFound();
            }
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "UserID", "Area", userReview.UtilizadorFK);
            ViewData["Utilizador2FK"] = new SelectList(_context.Utilizadores, "UserID", "Area", userReview.Utilizador2FK);
            return View(userReview);
        }

        // POST: UserReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReview,ValueReview,DateReview,UtilizadorFK,Utilizador2FK")] UserReview userReview)
        {
            if (id != userReview.IdReview)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserReviewExists(userReview.IdReview))
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
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "UserID", "Area", userReview.UtilizadorFK);
            ViewData["Utilizador2FK"] = new SelectList(_context.Utilizadores, "UserID", "Area", userReview.Utilizador2FK);
            return View(userReview);
        }

        // GET: UserReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserReview == null)
            {
                return NotFound();
            }

            var userReview = await _context.UserReview
                .Include(u => u.Utilizador)
                .Include(u => u.Utilizador2)
                .FirstOrDefaultAsync(m => m.IdReview == id);
            if (userReview == null)
            {
                return NotFound();
            }

            return View(userReview);
        }

        // POST: UserReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserReview == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserReview'  is null.");
            }
            var userReview = await _context.UserReview.FindAsync(id);
            var idUser = userReview.Utilizador2FK;
            if (userReview != null)
            {
                _context.UserReview.Remove(userReview);
            }
            
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Details", "Utilizadores", new { id = idUser });
        }

        private bool UserReviewExists(int id)
        {
          return _context.UserReview.Any(e => e.IdReview == id);
        }
    }
}
