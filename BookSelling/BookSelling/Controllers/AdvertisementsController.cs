using BookSelling.Data;
using BookSelling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookSelling.Data;
using BookSelling.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BookSelling.Controllers
{
    public class AdvertisementsController : Controller
    {

        /// <summary>
        /// this attribute refers the database of our project
        /// </summary>
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        /// <summary>
        /// variavel que recolhe os dados da pessoa que se autenticou
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;

        public AdvertisementsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;

        }

        // GET: Advertisements
        public async Task<IActionResult> Index()
        {

            /* execute the db command
             * select *
             * from Advertisements
             * 
             * and send Data to View
             */
            var applicationDbContext = _context.Advertisement.Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
            //return View(await _context.Advertisement.ToListAsync());

        }

        /// <summary>
        /// Metodo para apresentar os comentarios feitos pelos utilizadores
  
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateComentario(int IdAds, string comentario, int rating)
        {
            //recolher dados do utilizador
            var utilizador = _context.Utilizadores.Where(u => u.LinkID == _userManager.GetUserId(User)).FirstOrDefault();

            // será que este user já fez um comentário sobre este filme?
            var oldComentario = await _context.Reviews.Where(r => r.Utilizador == utilizador && r.AdsFK == IdAds).FirstOrDefaultAsync();

            if (oldComentario == null)
            {
                //variavel que contem os dados da review, do utilizador e sobre qual filme foi feita review
                var comment = new Reviews
                {
                    AdsFK = IdAds,
                    Comentario = comentario.Replace("\r\n", "<br />"),
                    Pontuacao = rating,
                    Data = DateTime.Now,
                    Visibilidade = true,
                    Utilizador = utilizador
                };
                //adiciona a review à Base de Dados
                _context.Reviews.Add(comment);
                //o utilizador já fez a sua review
                utilizador.ControlarReview = true;
                //guardar a alteração na Base de Dados
                _context.Utilizadores.Update(utilizador);
                //Guarda as alterações na Base de Dados
                await _context.SaveChangesAsync();
                //redirecionar para a página dos details do filme
                return RedirectToAction(nameof(Details), new { id = IdAds });
            }
            else
            {
                return RedirectToAction(nameof(Details), new { id = IdAds });
            }


        }

        // GET: Advertisements/Details/5
        public async Task<IActionResult> Details(int? id, int FavoriteValue)
        {
            if (id == null)
            {
                return NotFound();
            }

           

            ViewBag.FavoriteValue = 0;


            foreach (Utilizadores us in _context.Utilizadores)
            {
                foreach (var item in _context.Favorites)
                {
                    if (us.UserID == item.UtilizadoresID)
                    {
                        item.Utilizadores = us;
                    }
                }
            }

            foreach (var item in _context.Favorites)
            {
                if (User.Identity.Name == item.Utilizadores.Email)
                {
                    ViewBag.FavoriteValue = 1;
                }
            }

            var advertisement = await _context.Advertisement
                .Include(a => a.User)
                .Include(c => c.CategoriesList)
                .Include(f => f.ReviewsList)
                .ThenInclude(r => r.Utilizador)
                .FirstOrDefaultAsync(m => m.AdID == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddFavorite(int id)
        {

            // if advertisement not on favorite list, button shouldn't be pressed
            // if this is true then the user already has added this advertisement to his favorite list
            var flag = 0;
            var advert = new Advertisement();
            var user = new Utilizadores();
            int iddouser = 0;
            foreach (Favorite aux in _context.Favorites)
            {
                foreach (Utilizadores us in _context.Utilizadores)
                {
                    if (us.UserID == aux.UtilizadoresID)
                    {
                        aux.Utilizadores = us;
                    }
                }
                foreach (Advertisement a in _context.Advertisement)
                {
                    if (a.AdID == aux.AdvertisementID)
                    {
                        aux.Advertisement = a;
                    }
                }
                if (aux.AdvertisementID == id && aux.Utilizadores.Email == User.Identity.Name)
                {
                    flag++;
                    _context.Remove(aux);
                }
            }
            if (flag == 0)
            {
                //this means that the advertisement is not favorite yet
                foreach (Utilizadores axax in _context.Utilizadores)
                {
                    if (axax.Email == User.Identity.Name)
                    {
                        iddouser = axax.UserID;
                        user = axax;
                    }

                }
                foreach (Advertisement ad2 in _context.Advertisement)
                {
                    if (ad2.AdID == id)
                    {
                        advert = ad2;
                    }
                }
                var favorite = new Favorite
                {
                    AdvertisementID = id,
                    Advertisement = advert,
                    Utilizadores = user,
                    UtilizadoresID = iddouser
                };

                //foreach (Advertisement ad2 in _context.Advertisement)
                //{
                //    if (ad2.AdID == id)
                //    {
                //        ad2.Favorites.Add(favorite);
                //    }
                //}

                if (ModelState.IsValid)
                {
                    try
                    {
                        //add Favorite data to database
                        _context.Add(favorite);
                        //commit
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        // if the code arrives here, something wrong has appended
                        // we must fix the error, or at least report it

                        // add a model error to our code
                        ModelState.AddModelError("", "Something went wrong. I can not add it to the favorite list");
                        // eventually, before sending control to View
                        // report error. For instance, write a message to the disc
                        // or send an email to admin              

                        // send control to View
                        return RedirectToAction(nameof(Details), new { id = id });
                    }
                }

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = id });
        }

        // GET: Advertisements/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Set<Utilizadores>(), "UserID", "Email");
            return View();
        }

        // POST: Advertisements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("AdID,TypeofAdd,Title,Description,Price,ISBM,Photo,UserID,sold,Visibility,DateTime,User")] Advertisement advertisement, IFormFile newphoto, String typeAd, ICollection<String> ChoosenCategory)
        {
            ModelState.Remove("DateTime");
            ModelState.Remove("User");
            ModelState.Remove("Category");
            ModelState.Remove("Photo");

            /* we must process the image
             * 
             * if file is null
             * add a pre-define image to vet (default avatar)
             * else
             *  if file is not an image
             *  send an error message to user, asking for an image
             *  else
             *  - define the name that the image must have
             *  -add the file name to vetdata
             *  -save the file on the disk
             * 
             */
            //Console.WriteLine(newphoto);
            // Variable DateTime gets submission datetime
            advertisement.DateTime = DateTime.Now;
            //Variable sold gets false value since it was recently created
            advertisement.sold = false;
            //Variable Visibility gets true value so it shows once created
            advertisement.Visibility = true;

            foreach (String category in ChoosenCategory)
            {
                foreach (Category category2 in _context.Category)
                {
                    if (category2.NameCategory == category)
                    {
                        var ac = new AdvertsCategory
                        {
                            Advertisement = advertisement,
                            Category = category2
                        };
                        advertisement.CategoriesList.Add(ac);
                    }
                }
            }

            advertisement.TypeofAdd = typeAd;
            //advertisement.Photo = newphoto.FileName;

            foreach (Utilizadores user2 in _context.Utilizadores)
            {
                if (user2.Email == User.Identity.Name)
                {
                    advertisement.User = user2;
                }
            }

            if (ChoosenCategory.Count == 0)
            {
                ModelState.AddModelError("", "Please choose at least a category.");
                return View(advertisement);
            }

            if (newphoto == null)
            {
                ModelState.AddModelError("", "Please insert an image with a valid format(png/jpeg).");
                return View(advertisement);
            }
            else if (!(newphoto.ContentType == "image/jpeg" || newphoto.ContentType == "image/png" || newphoto.ContentType == "image/jpg"))
            {
                //write the error message
                ModelState.AddModelError("", "Please choose a valid format(png/jpeg)");
                //resend Control to View, with data provided by user
                return View(advertisement);
            }
            else
            {
                Guid g;
                g = Guid.NewGuid();
                string imageName = advertisement.Photo + "_" + g.ToString();
                string extensionOfImage = Path.GetExtension(newphoto.FileName).ToLower();
                imageName += extensionOfImage;
                advertisement.Photo = imageName;

            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                try
                {
                    //add advertisement data to database
                    _context.Add(advertisement);
                    //commit
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    // if the code arrives here, something wrong has appended
                    // we must fix the error, or at least report it

                    // add a model error to our code
                    ModelState.AddModelError("", "Something went wrong. I can not store data on database");
                    // eventually, before sending control to View
                    // report error. For instance, write a message to the disc
                    // or send an email to admin              

                    //// send control to View
                    return RedirectToAction("Index", "Home");
                    //return View(advertisement);
                }
                // save image file to disk
                //ask the server what address it wants to use
                string addressToStoreFile = _webHostEnvironment.WebRootPath;
                string newimglocation = Path.Combine(addressToStoreFile, "Photos", advertisement.Photo);

                //save image file to disk
                using var stream = new FileStream(newimglocation, FileMode.Create);
                await newphoto.CopyToAsync(stream);

                return RedirectToAction("Index", "Home");
                //return RedirectToAction(nameof(Index));

            }
            ViewData["UserID"] = new SelectList(_context.Set<Utilizadores>(), "UserID", "Email", advertisement.UserID);
            //return View(advertisement);
            return RedirectToAction("Index", "Home");
        }

        // GET: Advertisements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisement.FindAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Set<Utilizadores>(), "UserID", "Email", advertisement.UserID);
            return View(advertisement);
        }

        // POST: Advertisements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("AdID,TypeofAdd,Title,Price,ISBM,UserID,sold,Photo,Description,Visibility,DateTime")] Advertisement advertisement)
        {
            if (id != advertisement.AdID)
            {
                return NotFound();
            }
 

            ModelState.Remove("Visibility");
            ModelState.Remove("DateTime");
            ModelState.Remove("UserID");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advertisement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertisementExists(advertisement.AdID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Details", "Advertisements", new { id = advertisement.AdID });
            }
            ViewData["UserID"] = new SelectList(_context.Set<Utilizadores>(), "UserID", "Email", advertisement.UserID);
            //return View(advertisement);
            return RedirectToAction("Details", "Advertisements", new { id = advertisement.AdID });
        }

        // GET: Advertisements/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisement
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AdID == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // POST: Advertisements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisement = await _context.Advertisement.FindAsync(id);
            var advertID = advertisement.AdID;
            _context.Advertisement.Remove(advertisement);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Details", "Advertisements", new { id = advertID });
        }

        private bool AdvertisementExists(int id)
        {
            return _context.Advertisement.Any(e => e.AdID == id);
        }
    }
}