using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PesquisarCodigoPostal.Data;
using PesquisarCodigoPostal.Models;

namespace PesquisarCodigoPostal.Controllers
{
    public class CodigoPostalController : Controller
    {
        private readonly PesquisarCodigoPostalContext _context;

        public CodigoPostalController(PesquisarCodigoPostalContext context)
        {
            _context = context;
        }

        // GET: CodigoPostal
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodigoPostal.ToListAsync());
        }

        // GET: CodigoPostal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codigoPostal = await _context.CodigoPostal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codigoPostal == null)
            {
                return NotFound();
            }

            return View(codigoPostal);
        }

        // GET: CodigoPostal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CodigoPostal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoPostalString")] CodigoPostal codigoPostal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codigoPostal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codigoPostal);
        }

        // GET: CodigoPostal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codigoPostal = await _context.CodigoPostal.FindAsync(id);
            if (codigoPostal == null)
            {
                return NotFound();
            }
            return View(codigoPostal);
        }

        // POST: CodigoPostal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoPostalString")] CodigoPostal codigoPostal)
        {
            if (id != codigoPostal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codigoPostal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodigoPostalExists(codigoPostal.Id))
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
            return View(codigoPostal);
        }

        // GET: CodigoPostal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codigoPostal = await _context.CodigoPostal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codigoPostal == null)
            {
                return NotFound();
            }

            return View(codigoPostal);
        }

        // POST: CodigoPostal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codigoPostal = await _context.CodigoPostal.FindAsync(id);
            _context.CodigoPostal.Remove(codigoPostal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodigoPostalExists(int id)
        {
            return _context.CodigoPostal.Any(e => e.Id == id);
        }
    }
}
