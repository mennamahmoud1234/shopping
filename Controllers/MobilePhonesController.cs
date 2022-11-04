using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shopping.Data;
using shopping.Models;

namespace shopping.Controllers
{
    public class MobilePhonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MobilePhonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MobilePhones
        public async Task<IActionResult> Index()
        {
            return View(await _context.MobilePhone.ToListAsync());
        }

        // GET: MobilePhones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilePhone = await _context.MobilePhone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobilePhone == null)
            {
                return NotFound();
            }

            return View(mobilePhone);
        }

        // GET: MobilePhones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MobilePhones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Description,Images")] MobilePhone mobilePhone)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                   mobilePhone.Images = dataStream.ToArray();
                }
                _context.Add(mobilePhone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobilePhone);
        }

        // GET: MobilePhones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilePhone = await _context.MobilePhone.FindAsync(id);
            if (mobilePhone == null)
            {
                return NotFound();
            }
          
            return View(mobilePhone);
        }

        // POST: MobilePhones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Description,Images")] MobilePhone mobilePhone)
        {
            if (id != mobilePhone.Id)
            {
                return NotFound();
            }

           

            if (ModelState.IsValid)
            {
                if(mobilePhone.Images!=null)
                {

                    var file = Request.Form.Files.FirstOrDefault();
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        mobilePhone.Images = dataStream.ToArray();
                    }
                }
                else
                {
                    try
                    {



                        _context.Update(mobilePhone);
                        await _context.SaveChangesAsync();

                    }
                catch (DbUpdateConcurrencyException)
                    {
                        if (!MobilePhoneExists(mobilePhone.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(mobilePhone);
        }

        // GET: MobilePhones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilePhone = await _context.MobilePhone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobilePhone == null)
            {
                return NotFound();
            }

            return View(mobilePhone);
        }

        // POST: MobilePhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mobilePhone = await _context.MobilePhone.FindAsync(id);
            _context.MobilePhone.Remove(mobilePhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobilePhoneExists(int id)
        {
            return _context.MobilePhone.Any(e => e.Id == id);
        }
    }
}










