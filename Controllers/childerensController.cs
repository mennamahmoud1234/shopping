using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using shopping.Data;
using shopping.Models;

namespace shopping.Controllers
{
    public class childerensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public childerensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: childerens
        public async Task<IActionResult> Index()
        {
            return View(await _context.childeren.ToListAsync());
        }

        // GET: childerens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childeren = await _context.childeren
                .FirstOrDefaultAsync(m => m.Id == id);
            if (childeren == null)
            {
                return NotFound();
            }

            return View(childeren);
        }

        // GET: childerens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: childerens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Description,Images")] childeren childeren)
        {
            if (ModelState.IsValid)
            {

                var file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                   childeren.Images = dataStream.ToArray();
                }
                _context.Add(childeren);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(childeren);
        }

        // GET: childerens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chi = await _context.childeren.FindAsync(id);

            if (chi == null)
            {
                return NotFound();
            }
            return View(chi);
        }

        // POST: childerens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Salery,Description")] childeren childeren)
        {


           

            if (id != childeren.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

              
                try
                {


                    if (childeren.Images != null)
                    {

                        var file = Request.Form.Files.FirstOrDefault();
                        using (var dataStream = new MemoryStream())
                        {
                            await file.CopyToAsync(dataStream);
                           childeren.Images = dataStream.ToArray();
                        }
                    }


                    else
                    {






                        var file = Request.Form.Files;
                            var images=file.FirstOrDefault();

                        using var dataStream = new MemoryStream();
                          
                                await images.CopyToAsync(dataStream);
                        childeren.Images = dataStream.ToArray();
                           
                       
                    }
                    _context.Update(childeren);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!childerenExists(childeren.Id))
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
            return View(childeren);
        }

        // GET: childerens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childeren = await _context.childeren
                .FirstOrDefaultAsync(m => m.Id == id);
            if (childeren == null)
            {
                return NotFound();
            }

            return View(childeren);
        }

        // POST: childerens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var childeren = await _context.childeren.FindAsync(id);
            _context.childeren.Remove(childeren);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool childerenExists(int id)
        {
            return _context.childeren.Any(e => e.Id == id);
        }
    }
}
