using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobilePoint.Data;

namespace MobilePoint.Controllers
{
    public class PhonesController : Controller
    {
        private readonly MobilePointDbContext _context;

        public PhonesController(MobilePointDbContext context)
        {
            _context = context;
        }

        // GET: Phones
        public async Task<IActionResult> Index()
        {
            var mobilePointDbContext = _context.Phones.Include(p => p.BrandModels);
            return View(await mobilePointDbContext.ToListAsync());
        }

        // GET: Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Phones == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.BrandModels)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }
        [Authorize(Roles = "Admin")]
        // GET: Phones/Create
        public IActionResult Create()
        {          
            ViewData["BrandModelId"] = _context.BrandModels.Select(x =>
            new SelectListItem
            {
                Text = x.Brand + " " + x.Model,
                Value = x.Id.ToString()
            });
            return View();
        }

        // POST: Phones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandModelId,Color,ImageURL,Price")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                phone.RegisterOn = DateTime.Now;
                _context.Phones.Add(phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandModelId"] = _context.BrandModels.Select(x =>
            new SelectListItem
            {
                Text = x.Brand + " " + x.Model,
                Value = x.Id.ToString()
            });
            return View(phone);
        }

        // GET: Phones/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Phones == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            ViewData["BrandModelId"] = _context.BrandModels.Select(x =>
            new SelectListItem
            {
                Text = x.Brand + " " + x.Model,
                Value = x.Id.ToString()
            });
            return View(phone);
        }

        // POST: Phones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandModelId,Color,ImageURL,Price")] Phone phone)
        {
            if (id != phone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    phone.RegisterOn = DateTime.Now;
                    _context.Phones.Update(phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.Id))
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
            ViewData["BrandModelId"] = _context.BrandModels.Select(x =>
            new SelectListItem
            {
                Text = x.Brand + " " + x.Model,
                Value = x.Id.ToString()
            });
            return View(phone);
        }

        // GET: Phones/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Phones == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.BrandModels)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Phones == null)
            {
                return Problem("Entity set 'MobilePointDbContext.Phones'  is null.");
            }
            var phone = await _context.Phones.FindAsync(id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(int id)
        {
          return _context.Phones.Any(e => e.Id == id);
        }
    }
}
