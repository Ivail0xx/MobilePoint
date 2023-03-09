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
    [Authorize(Roles = "Admin")]
    public class BrandModelsController : Controller
    {
        private readonly MobilePointDbContext _context;

        public BrandModelsController(MobilePointDbContext context)
        {
            _context = context;
        }

        // GET: BrandModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.BrandModels.ToListAsync());
        }

        // GET: BrandModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BrandModels == null)
            {
                return NotFound();
            }

            var brandModel = await _context.BrandModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brandModel == null)
            {
                return NotFound();
            }

            return View(brandModel);
        }

        // GET: BrandModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BrandModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Brand,Model,Specification")] BrandModel brandModel)
        {
            if (ModelState.IsValid)
            {
                brandModel.RegisterOn = DateTime.Now;
                _context.BrandModels.Add(brandModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brandModel);
        }

        // GET: BrandModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BrandModels == null)
            {
                return NotFound();
            }

            var brandModel = await _context.BrandModels.FindAsync(id);
            if (brandModel == null)
            {
                return NotFound();
            }
            return View(brandModel);
        }

        // POST: BrandModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Specification")] BrandModel brandModel)
        {
            if (id != brandModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    brandModel.RegisterOn = DateTime.Now;
                    _context.BrandModels.Update(brandModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandModelExists(brandModel.Id))
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
            return View(brandModel);
        }

        // GET: BrandModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BrandModels == null)
            {
                return NotFound();
            }

            var brandModel = await _context.BrandModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brandModel == null)
            {
                return NotFound();
            }

            return View(brandModel);
        }

        // POST: BrandModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BrandModels == null)
            {
                return Problem("Entity set 'MobilePointDbContext.BrandModels'  is null.");
            }
            var brandModel = await _context.BrandModels.FindAsync(id);
            if (brandModel != null)
            {
                _context.BrandModels.Remove(brandModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandModelExists(int id)
        {
          return _context.BrandModels.Any(e => e.Id == id);
        }
    }
}
