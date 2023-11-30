using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Avaliacao.Domain.Entities;
using API_Avaliacao.Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Avaliacao_Api.Controllers
{
    public class CertamesController : Controller
    {
        private readonly ConnectionDbContext _context;

        public CertamesController(ConnectionDbContext context)
        {
            _context = context;
        }

        // GET: Certames
        public async Task<IActionResult> Index()
        {
              return _context.Certames != null ? 
                          View(await _context.Certames.ToListAsync()) :
                          Problem("Entity set 'ConnectionDbContext.Certames'  is null.");
        }

        // GET: Certames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Certames == null)
            {
                return NotFound();
            }

            var certame = await _context.Certames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certame == null)
            {
                return NotFound();
            }

            return View(certame);
        }

        // GET: Certames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Certames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,DataInicio,DataFim")] Certame certame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certame);
        }

        // GET: Certames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Certames == null)
            {
                return NotFound();
            }

            var certame = await _context.Certames.FindAsync(id);
            if (certame == null)
            {
                return NotFound();
            }
            return View(certame);
        }

        // POST: Certames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,DataInicio,DataFim")] Certame certame)
        {
            if (id != certame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertameExists((int)certame.Id))
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
            return View(certame);
        }

        // GET: Certames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Certames == null)
            {
                return NotFound();
            }

            var certame = await _context.Certames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certame == null)
            {
                return NotFound();
            }

            return View(certame);
        }

        // POST: Certames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Certames == null)
            {
                return Problem("Entity set 'ConnectionDbContext.Certames'  is null.");
            }
            var certame = await _context.Certames.FindAsync(id);
            if (certame != null)
            {
                _context.Certames.Remove(certame);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertameExists(int id)
        {
          return (_context.Certames?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
