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
    public class AdvertisementsController : Controller
    {

        /// <summary>
        /// this attribute refers the database of our project
        /// </summary>
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdvertisementsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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

        // GET: Advertisements/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Advertisements/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "UserID", "Email");
            return View();
        }

        // POST: Advertisements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // 
        public async Task<IActionResult> Create([Bind("AdID,TypeofAdd,Title,Description,Price,ISBM,Photo,UserID,sold,Visibility,DateTime")] Advertisement advertisement, IFormFile newphoto)
        {
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
            
            //advertisement.Photo = newphoto.FileName;


            if (newphoto == null)
            {
                ModelState.AddModelError("", "Please insert an image with a valid format(png/jpeg)");
                return View(advertisement);
            }
            else if (!(newphoto.ContentType == ".jpeg" || newphoto.ContentType == ".png" || newphoto.ContentType == ".jpg"))
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



            if (ModelState.IsValid)
            {
                try
                {
                    //add advertisement data to database
                    _context.Add(advertisement);
                    //commit
                    await _context.SaveChangesAsync();
                }
                catch (Exception) {
                    // if the code arrives here, something wrong has appended
                    // we must fix the error, or at least report it

                    // add a model error to our code
                    ModelState.AddModelError("", "Something went wrong. I can not store data on database");
                    // eventually, before sending control to View
                    // report error. For instance, write a message to the disc
                    // or send an email to admin              

                    // send control to View
                    return View(advertisement);
                }
                // save image file to disk
                //ask the server what address it wants to use
                string addressToStoreFile = _webHostEnvironment.WebRootPath;
                string newimglocation = Path.Combine(addressToStoreFile, "Photos", advertisement.Photo);

                //save image file to disk
                using var stream = new FileStream(newimglocation, FileMode.Create);
                await newphoto.CopyToAsync(stream);

                return RedirectToAction(nameof(Index));

            }
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "UserID", "Email", advertisement.UserID);
            return View(advertisement);
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
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "UserID", "Email", advertisement.UserID);
            return View(advertisement);
        }

        // POST: Advertisements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdID,TypeofAdd,Price,ISBM,UserID,sold,Visibility,DateTime")] Advertisement advertisement)
        {
            if (id != advertisement.AdID)
            {
                return NotFound();
            }

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
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "UserID", "Email", advertisement.UserID);
            return View(advertisement);
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
            _context.Advertisement.Remove(advertisement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(int id)
        {
            return _context.Advertisement.Any(e => e.AdID == id);
        }
    }
}
