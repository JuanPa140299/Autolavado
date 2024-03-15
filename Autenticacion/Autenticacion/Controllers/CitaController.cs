using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autenticacion.Data;
using Autenticacion.Models;
using Microsoft.AspNetCore.Identity;


namespace Autenticacion.Controllers
{
    public class CitaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cita


        public async Task<IActionResult> Index()
        {
            AspNetUsers A = new AspNetUsers();
           var applicationDbContext = _context.Cita.Include(c => c.Servicio);
           return View(await applicationDbContext.ToListAsync());
         





        }

        // GET: Cita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Servicio)
                .FirstOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }
      

        // GET: Cita/Create
        public IActionResult Create()
        {
            ViewData["ServicioId"] = new SelectList(_context.Set<Servicio>(), "ServicioId", "ServicioId");
            return View();
        }

        // POST: Cita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        IdentityUser user = new IdentityUser();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitaId","Fecha,ServicioId")] Cita cita)
        {
            Servicio Servicio = new Servicio();
            if (ModelState.IsValid)
            {
                cita.ClienteId = user.Id;
                cita.Estado = "Pendiente";
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServicioId"] = new SelectList(_context.Set<Servicio>(), "ServicioId", "ServicioId", cita.ServicioId);
            ViewBag.Servicio = new SelectList(_context.Servicio, "ServicioId", "Nombre");

            return View(cita);
        
        }



        // GET: Cita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["ServicioId"] = new SelectList(_context.Set<Servicio>(), "ServicioId", "ServicioId", cita.ServicioId);
            return View(cita);
        }

        // POST: Cita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitaId,ClienteId,Fecha,ServicioId,Estado")] Cita cita)
        {

            if (id != cita.CitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.CitaId))
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
            ViewData["ServicioId"] = new SelectList(_context.Set<Servicio>(), "ServicioId", "ServicioId", cita.ServicioId);
            return View(cita);
        }

        // GET: Cita/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Servicio)
                .FirstOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cita == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cita'  is null.");
            }
            var cita = await _context.Cita.FindAsync(id);
            if (cita != null)
            {
                _context.Cita.Remove(cita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
          return (_context.Cita?.Any(e => e.CitaId == id)).GetValueOrDefault();
        }
    }
}
