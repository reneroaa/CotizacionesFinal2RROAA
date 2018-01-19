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



        public Persona validate(){
            //validacion de rut
            if(!validarRut(this.Rut)){
                throw new ArgumentException("RUT no valido");
            }
            return this;
        }

        public bool validarRut(string rut ) {
                    
            bool validacion = false;
            try {
                rut =  rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
        
                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));
        
                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10) {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char) (s != 0 ? s + 47 : 75)) {
                validacion = true;
                }
            } catch (Exception) {
            }
            return validacion;
        }



	}
    
}