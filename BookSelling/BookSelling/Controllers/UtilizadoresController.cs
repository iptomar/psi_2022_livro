using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookSelling.Data;
using BookSelling.Models;
using Microsoft.AspNetCore.Identity;

namespace BookSelling.Controllers
{
    public class UtilizadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public UtilizadoresController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Utilizadores
        public async Task<IActionResult> Index()
        {
              return View(await _context.Utilizadores.ToListAsync());
        }

        // POST: Jogos/CreateRating
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRating(int userId, double nota)
        {

            //variável que vai buscar o Utilizador que escreveu a Review
            var utilizador = _context.Utilizadores.Where(u => u.ID == _userManager.GetUserId(User)).FirstOrDefault();

            //Colocar nos dados da Review os daods introduzidos pelo Utilizador
            var review = new UserReview
            {
                ValueReview = nota,
                DateReview = DateTime.Now,
                Utilizador = utilizador,
                Utilizador2FK = userId
            };

            //Adiciona a base de dados a review
            _context.Add(review);
            await _context.SaveChangesAsync();
            //Guarda as alterações feitas na base de dados
            return RedirectToAction(nameof(Details), new { id = userId });
        }

        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id, int value, int reviwed)
        {
            int soma = 0;
            int media = 0;
            var result = _context.UserReview.Where(b => b.Utilizador2FK == id);
            int num = _context.UserReview.Count(b => b.Utilizador2FK == id);

            foreach (var item in _context.UserReview)
            {
                foreach (var item2 in _context.Utilizadores)
                {
                    if (item.Utilizador2FK == item2.UserID)
                    {
                        item.Utilizador2 = item2;
                    }
                    if (item.UtilizadorFK == item2.UserID)
                    {
                        item.Utilizador = item2;
                    }
                }
            }

            foreach (var item in _context.UserReview)
            {
                if (item.Utilizador2FK == reviwed && User.Identity.Name == item.Utilizador.Email)
                {
                    //item.ValueReview = value;
                    var item3 = _context.UserReview.First(a => a == item);
                    item3.ValueReview = value;
                }
            }

            _context.SaveChanges();

            if (result.Any())
            {
                foreach (var item in result)
                {
                    soma = soma + (int)item.ValueReview;
                }
                media = soma / num;
                foreach (var item in _context.Utilizadores)
                {
                    if (item.UserID == id)
                    {
                        item.Reputation = media;
                    }
                }
            }

            if (id == null || _context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores
                 .Where(a => a.UserID == id)
                                            .Include(a => a.UtilizadoresLeft)
                                            .Include(b => b.UtilizadoresRight)
                                        .FirstOrDefaultAsync();
            if (utilizadores == null)
            {
                return NotFound();
            }

            return View(utilizadores);
        }

        // GET: Utilizadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,UserName,ID,Email,Reputation,Area,BooksSold,Telephone")] Utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilizadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilizadores);
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores.FindAsync(id);
            if (utilizadores == null)
            {
                return NotFound();
            }
            return View(utilizadores);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,UserName,ID,Email,Reputation,Area,BooksSold,Telephone")] Utilizadores utilizadores, String username, String email)
        {
            if (id != utilizadores.UserID)
            {
                return NotFound();
            }
            ModelState.Remove("UserID");
            ModelState.Remove("ID");
            ModelState.Remove("BookSold");
            ModelState.Remove("Reputation");

            //foreach (var user in _context.Utilizadores)
            //{
            //    if (user.Email == email && User.Identity.Name != email)
            //    {
            //        ViewBag.ErrorMessage = "This email is already in use.";
            //        return View(utilizadores);
            //    }
            //}

            //foreach (var user in _context.Utilizadores)
            //{
            //    if (user.UserName == username && User.Identity.Name != email)
            //    {
            //        ViewBag.ErrorMessage = "This username is already in use.";
            //        return View();
            //    }
            //}

            //foreach (var user in _context.Users)
            //{
            //    if (user.Email == User.Identity.Name)
            //    {
            //        var user2 = _context.Users.First(a => a == user);
            //        user2.Email = email;
            //    }
            //}

            //_context.SaveChanges();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadoresExists(utilizadores.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //return PartialView("Details", utilizadores);
                return RedirectToAction(nameof(Details), new { id = id });
                //return RedirectToAction(nameof(Details));
            }

            //return PartialView("Details", utilizadores);
            //return View("Details", utilizadores);
            return RedirectToAction(nameof(Details), new { id = id });
        }

        // GET: Utilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (utilizadores == null)
            {
                return NotFound();
            }

            return View(utilizadores);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Utilizadores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Utilizadores'  is null.");
            }
            var utilizadores = await _context.Utilizadores.FindAsync(id);
            if (utilizadores != null)
            {
                _context.Utilizadores.Remove(utilizadores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadoresExists(int id)
        {
          return _context.Utilizadores.Any(e => e.UserID == id);
        }
    }
}
