using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoMute.Web.Data;
using CoMute.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoMute.Web.Controllers
{
    public class CarPoolModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarPoolModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarPoolModels
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.CarPoolModel != null ? 
                          View(await _context.CarPoolModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CarPoolModel'  is null.");
        }
        // GET: CarPoolModels/SearchCarPool
        public async Task<IActionResult> SearchCarPool()
        {
            return View();
        }

        // GET: CarPoolModels/ShowSearchResjults
        public async Task<IActionResult> ShowSearchResults( string SearchPool)
        {
            return View("Index", await _context.CarPoolModel.Where( j => j.Origin.Contains(SearchPool)).ToListAsync());
        }

        // GET: CarPoolModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarPoolModel == null)
            {
                return NotFound();
            }

            var carPoolModel = await _context.CarPoolModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carPoolModel == null)
            {
                return NotFound();
            }

            return View(carPoolModel);
        }

        // GET: CarPoolModels/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarPoolModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartureTime,ArrivalTime,Origin,DaysAvailabe,Destination,AvailableSeats,OwnerLeader,Notes")] CarPoolModel carPoolModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carPoolModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carPoolModel);
        }

        // GET: CarPoolModels/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarPoolModel == null)
            {
                return NotFound();
            }

            var carPoolModel = await _context.CarPoolModel.FindAsync(id);
            if (carPoolModel == null)
            {
                return NotFound();
            }
            return View(carPoolModel);
        }

        // POST: CarPoolModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartureTime,ArrivalTime,Origin,DaysAvailabe,Destination,AvailableSeats,OwnerLeader,Notes")] CarPoolModel carPoolModel)
        {
            if (id != carPoolModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carPoolModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarPoolModelExists(carPoolModel.Id))
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
            return View(carPoolModel);
        }

        // GET: CarPoolModels/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarPoolModel == null)
            {
                return NotFound();
            }

            var carPoolModel = await _context.CarPoolModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carPoolModel == null)
            {
                return NotFound();
            }

            return View(carPoolModel);
        }

        // POST: CarPoolModels/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarPoolModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CarPoolModel'  is null.");
            }
            var carPoolModel = await _context.CarPoolModel.FindAsync(id);
            if (carPoolModel != null)
            {
                _context.CarPoolModel.Remove(carPoolModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarPoolModelExists(int id)
        {
          return (_context.CarPoolModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
