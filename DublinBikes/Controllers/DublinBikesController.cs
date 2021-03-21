using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DublinBikes.Data;
using DublinBikes.Models;

namespace DublinBikes.Controllers
{
    public class DublinBikesController : Controller
    {
        private readonly MvcBikeContext _context;

        public DublinBikesController(MvcBikeContext context)
        {
            _context = context;
        }

        // GET: DublinBikes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DublinBike.ToListAsync());
        }

        // GET: DublinBikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dublinBike = await _context.DublinBike
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dublinBike == null)
            {
                return NotFound();
            }

            return View(dublinBike);
        }

        // GET: DublinBikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DublinBikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,ContractName,Name,Address,Latitude,Longitude,Banking,Available_bikes,Available_stands,Capacity,Status")] DublinBike dublinBike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dublinBike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dublinBike);
        }

        // GET: DublinBikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dublinBike = await _context.DublinBike.FindAsync(id);
            if (dublinBike == null)
            {
                return NotFound();
            }
            return View(dublinBike);
        }

        // POST: DublinBikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,ContractName,Name,Address,Latitude,Longitude,Banking,Available_bikes,Available_stands,Capacity,Status")] DublinBike dublinBike)
        {
            if (id != dublinBike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dublinBike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DublinBikeExists(dublinBike.Id))
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
            return View(dublinBike);
        }

        // GET: DublinBikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dublinBike = await _context.DublinBike
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dublinBike == null)
            {
                return NotFound();
            }

            return View(dublinBike);
        }

        // POST: DublinBikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dublinBike = await _context.DublinBike.FindAsync(id);
            _context.DublinBike.Remove(dublinBike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DublinBikeExists(int id)
        {
            return _context.DublinBike.Any(e => e.Id == id);
        }
    }
}
