using System;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Archivo donde se definen las clases del Dominio del problema.
/// </summary>
namespace Cotizaciones.Models
{

    /// <summary>
    /// Clase que representa a una cotizacion en el Sistema.
    /// </summary>
    /// <remarks>
    /// Esta clase pertenece al modelo del Dominio y posee las siguientes restricciones:
    /// - No permite valores null en sus atributos.
    /// </remarks>
    public class Cotizacion
    {

        //atributos de la clase cotización
        public int ID { get; set; }
        public string nombreCliente{get ; set; }
        public string descripcionCotizacion{get; set; }
        public int valorCotizacion{get; set; }
        public string estadoCotizacion{get; set; }
        public DateTime fechaCotizacion {get; set; }
        public DateTime fechaValidez{get; set; }
        public String PersonaRut {get;set; }
        [ForeignKey("PersonaRut")]
        public Persona persona {get; set;}

    }
}