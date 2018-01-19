using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cotizaciones.Data;
using Cotizaciones.Models;

//Controlador para la clase Persona
//En este controlador se designa un namespace dentro del cuál se gestionan los elementos ingresados
//manualmente a las vistas con la base de datos del sistema
//
//Se controlan gestión de datos entre vistas del modelo Persona (Index, create, delete, details, edit) y BD.
// 

namespace Cotizaciones.Controllers
{
    public class PersonaController : Controller
    {
        private readonly CotizacionesContext _context;

        public PersonaController(CotizacionesContext context)
        {
            _context = context;
        }

        // GET: Persona
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personas.ToListAsync());
        }

        // GET: Persona/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .SingleOrDefaultAsync(m => m.Rut == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Persona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rut,Nombre,Paterno,Materno")] Persona persona){
            //var listaPersona = _context.Personas.Where(m => m.Rut == persona.Rut);

            //if(listaPersona == null){
              //  return NotFound();
            //}else
            //{
              //  int cant = listaPersona.Count();
                //if (listaPersona.Count() == 0){
                  //  if (ModelState.IsValid){
                    //        _context.Add(persona);
                      //      await _context.SaveChangesAsync();
                        //    return RedirectToAction(nameof(Index));
                     //}
                   // return View(persona);
               // }else{      
                    //agregar popup de rut ya existe!  
                 //   ModelState.AddModelError("rut", "El Rut ingresado ya existe en el sistema!, intenta con otro Rut.");           
                    //return RedirectToAction(nameof(Create));
                   // return View (persona);
                   //}
            //}

            if (ModelState.IsValid)
            {
                if(Persona.validarRut(persona.Rut)){
                    _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
                               
            }
            return View(persona);

        }

        // GET: Persona/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.SingleOrDefaultAsync(m => m.Rut == id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Rut,Nombre,Paterno,Materno")] Persona persona)
        {
            if (id != persona.Rut)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.Rut))
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
            return View(persona);
        }

        // GET: Persona/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .SingleOrDefaultAsync(m => m.Rut == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var persona = await _context.Personas.SingleOrDefaultAsync(m => m.Rut == id);
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(string id)
        {
            return _context.Personas.Any(e => e.Rut == id);
        }

    }
}
