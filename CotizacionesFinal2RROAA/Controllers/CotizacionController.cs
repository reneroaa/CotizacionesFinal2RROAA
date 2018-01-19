using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cotizaciones.Data;
using Cotizaciones.Models;

//Controlador para la clase Cotización
//En este controlador se designa un namespace dentro del cuál se gestionan los elementos ingresados
//manualmente a las vistas con la base de datos del sistema
//
//Se controlan gestión de datos entre vistas del modelo Cotización (Index, create, delete, details, edit) y BD.
// 
namespace Cotizaciones.Controllers
{
    public class CotizacionController : Controller
    {
        private readonly CotizacionesContext _context;

        public CotizacionController(CotizacionesContext context)
        {
            _context = context;
        }

        // GET: Cotizacion
        public async Task<IActionResult> Index()
        {
            var cotizacionesContext = _context.Cotizacion.Include(c => c.persona);
            return View(await cotizacionesContext.ToListAsync());
        }

        // GET: Cotizacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion
                .Include(c => c.persona)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // GET: Cotizacion/Create
        public IActionResult Create()
        {
            ViewData["PersonaRut"] = new SelectList(_context.Personas, "Nombre", "Rut");
            return View();
        }

        // POST: Cotizacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nombreCliente,descripcionCotizacion,valorCotizacion,estadoCotizacion,fechaCotizacion,fechaValidez,PersonaRut")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cotizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaRut"] = new SelectList(_context.Personas, "Rut", "Rut", cotizacion.PersonaRut);
            return View(cotizacion);
        }

        // GET: Cotizacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion.SingleOrDefaultAsync(m => m.ID == id);
            if (cotizacion == null)
            {
                return NotFound();
            }
            ViewData["PersonaRut"] = new SelectList(_context.Personas, "Rut", "Rut", cotizacion.PersonaRut);
            return View(cotizacion);
        }

        // POST: Cotizacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nombreCliente,descripcionCotizacion,valorCotizacion,estadoCotizacion,fechaCotizacion,fechaValidez,PersonaRut")] Cotizacion cotizacion)
        {
            if (id != cotizacion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionExists(cotizacion.ID))
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
            ViewData["PersonaRut"] = new SelectList(_context.Personas, "Rut", "Rut", cotizacion.PersonaRut);
            return View(cotizacion);
        }

        // GET: Cotizacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion
                .Include(c => c.persona)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // POST: Cotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cotizacion = await _context.Cotizacion.SingleOrDefaultAsync(m => m.ID == id);
            _context.Cotizacion.Remove(cotizacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotizacionExists(int id)
        {
            return _context.Cotizacion.Any(e => e.ID == id);
        }
    }
}
