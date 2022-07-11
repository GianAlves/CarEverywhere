using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarEverywhere.Data;
using CarEverywhere.Models;
using CarEverywhere.Models.ViewModel;

namespace CarEverywhere.Controllers
{
    public class RentsController : Controller
    {
        private readonly CarEverywhereContext _context;

        public RentsController(CarEverywhereContext context)
        {
            _context = context;
        }

        // GET: Rents
        public IActionResult Index()
        {
            // Create a list of rentals, including car and client, to show in index.
            var list = _context.Rent.Include(r => r.Car).Include(r => r.Client).ToList();
            return View(list);
        }

        // GET: Rents/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }
            // Create a rental item, including car and client, to show in details.
            var rent = _context.Rent.Include(r => r.Car).Include(r => r.Client).FirstOrDefault(r => r.Id == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // GET: Rents/Create
        public IActionResult Create()
        {
            /*
                Creates a viewModel object that gathers rental data, car data, and client data.
                Having this data, it is possible to create a select box of items,
                both for cars and clients, so that the user can choose when registering rentals.
             */
            var viewModel = new RentFormViewModel();
            viewModel.Cars = _context.Car.ToList();
            viewModel.Clients = _context.Client.ToList();

            return View(viewModel);
        }

        // POST: Rents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rent rent)
        {
            _context.Add(rent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Rents/Edit/5

        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var rent = _context.Rent.Include(r => r.Car).Include(r => r.Client).FirstOrDefault(r => r.Id == id);
            if (rent == null)
            {
                return NotFound();
            }

            /*
                Creates a viewModel object that gathers rental data, car data, and client data.
                Having this data, it is possible to fill them in the selection boxes,
                being able to be edited if the user wants.
             */
            var viewModel = new RentFormViewModel();
            viewModel.Cars = _context.Car.ToList();
            viewModel.Clients = _context.Client.ToList();
            viewModel.Rent = rent;
            return View(viewModel);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Rent rent)
        {
            _context.Rent.Update(rent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Rents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            // Create a rental item, including car and client, to show on the delete page.
            var rent = _context.Rent.Include(r => r.Car).Include(r => r.Client).FirstOrDefault(r => r.Id == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rent == null)
            {
                return Problem("Entity set 'CarEverywhereContext.Rent'  is null.");
            }
            var rent = await _context.Rent.FindAsync(id);
            if (rent != null)
            {
                _context.Rent.Remove(rent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentExists(int id)
        {
          return (_context.Rent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
