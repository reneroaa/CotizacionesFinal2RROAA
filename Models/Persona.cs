using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// Archivo donde se definen las clases del Dominio del problema.
/// </summary>
namespace Cotizaciones.Models
{

    /// <summary>
    /// Clase que representa a una persona en el Sistema.
    /// </summary>
    public class Persona
    {
        public String Rut { get; set; }

        public string Nombre { get; set; }

        public string Paterno { get; set; }

        public string Materno { get; set; } 


	}
    
}