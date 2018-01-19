using System;
using Cotizaciones.Models;
using System.Collections.Generic;
using System.Linq;
using Cotizaciones.Data;

/// <summary>
/// Archivo donde se definen las querys de la base de datos
/// </summary>
namespace Cotizaciones.Services{

    /// <summary>
    /// Clase que representa a las consultas que se realizaran a la base de datos
    /// </summary>

    public class CotizacionesRepository{
        private readonly CotizacionesContext _context;

        public CotizacionesRepository(CotizacionesContext context){
            _context = context;
        }
        public List<Cotizacion> ObtenerCotizaciones(String rutPer){
            using (_context){
                var cotizaciones = _context.Cotizaciones
                .Where (b => b.PersonaRut==rutPer)
                .ToList();

                return cotizaciones;
            }
        }
    }
}