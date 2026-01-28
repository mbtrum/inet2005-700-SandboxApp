using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SandboxApp.Data;
using SandboxApp.Models;

namespace SandboxApp.Controllers
{
    public class PhotosController : Controller
    {
        private readonly SandboxAppContext _context;

        // Constructor
        // Dependency injection to pass context into this class.
        public PhotosController(SandboxAppContext context)
        {
            // Initialize context in the constructor
            _context = context;
        }

        // GET: Photos
        public async Task<IActionResult> Index()
        {
            // Get a list of all photos
            List<Photo> photos = await _context.Photo.ToListAsync();

            // Pass gthe list into the view
            return View(photos);
        }

        // Synchronous version of Index()
        //public IActionResult Index()
        //{
        //    var photos = _context.Photo.ToList();
        //    return View(photos);
        //}

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // check if id is missing in URL
            if (id == null)
            {
                return NotFound(); // http 404
            }

            // Find a photo with m.Id == id
            var photo = await _context.Photo.FirstOrDefaultAsync(m => m.Id == id);

            // record not found in database
            if (photo == null)
            {
                return NotFound(); // http 404
            }

            // Pass the photo into the view
            return View(photo);
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            // return empty form to add new photo
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ImageFilename")] Photo photo) // removed CreatedDate from binding
        {
            // Set the created date
            photo.CreatedDate = DateTime.Now;

            // Entity Framework data validation
            if (ModelState.IsValid)
            {
                // Add photo object to context
                _context.Add(photo);

                // Save the context changes to database
                await _context.SaveChangesAsync();

                // Redirect to Index action
                return RedirectToAction(nameof(Index));
            }

            // Pass the photo to the view
            return View(photo);
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photo.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ImageFilename,CreatedDate")] Photo photo)
        {
            if (id != photo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(photo.Id))
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
            return View(photo);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photo = await _context.Photo.FindAsync(id);
            if (photo != null)
            {
                _context.Photo.Remove(photo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotoExists(int id)
        {
            return _context.Photo.Any(e => e.Id == id);
        }
    }
}
