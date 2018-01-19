using System;
using Xunit; 
using Cotizaciones.Models;
//using CotizacionesFinal2RROAA.

//Clase que realiza las pruebas unitarias para el sistema de cotizaciones

namespace CotizacionesFinal2RROAAtesting
{
    public class UnitTest1
    {

        /// <summary>
        /// Casos de Rut que estan bien escritos pero les falta el guion de DV requerido
        /// </summary>
        [Theory]
        [InlineData("171325021")]
        [InlineData("89938627")]
        [InlineData("103674395")]
        [InlineData("191203978")]  
        public void retornarExcepcionPorFaltaGuionVerificador(string rutPrueba)
        {
            var prueba = new Persona();
            prueba.Rut = rutPrueba;
            Exception ex = Assert.Throws<ArgumentException>(() => prueba.validate());

            Assert.Equal("RUT no valido", ex.Message);
        }
        
        /// <summary>
        /// RUTs con su DV mal escrito, se retorna excepcion
        /// </summary>
        [Theory]
        [InlineData("171325027")]
        [InlineData("187903395")]
        [InlineData("103674396")]
        [InlineData("191203979")]  
        public void retornarExcepcionPorMalDigitoVerificador(string rutPrueba)
        {
            var prueba = new Persona();
            prueba.Rut = rutPrueba;
            Exception ex = Assert.Throws<ArgumentException>(() => prueba.validate());

            Assert.Equal("RUT no valido" , ex.Message);
        }


                /// <summary>
        /// Prueba unitaria que retorna excepcion por no tener guion verificador
        /// El RUT entregado tiene su digito verificador correcto
        /// </summary>
        [Fact]

        public void retornarExcepcionPorGuionVerificador()
        {
            var result = new Persona();
            result.Rut = "187903394";

            Exception ex = Assert.Throws<ArgumentException>(() => result.validate());

            Assert.Equal("RUT no valido", ex.Message);
        }
        

        /// <summary>
        /// Esta prueba muestra que el rut ingresado es correcto, el metodo validate() retorna la misma persona
        /// </summary>
        [Fact]
        public void retornarPersonaPorRutCorrecto()
        {
            var prueba = new Persona();
            prueba.Rut = "18790339-4";
            var esperado = new Persona();
            esperado = prueba.validate();
            ///Si la persona retornada es la misma que la que se ingreso 
            Assert.Equal(prueba,esperado);
        }
        
        /// <summary>
        /// Casos de ruts con buen formato y DV correcto
        /// </summary>
        [Theory]
        [InlineData("18.790.339-4")] //Rut Persona
        [InlineData("18128077-8")] //Rut Persona
        [InlineData("18.128.077-8")] //Rut Persona


        public void retornarPersonaFormatoCorrecto(string rutPrueba)
        {
            var prueba = new Persona();
            prueba.Rut = rutPrueba;
            var esperado = prueba.validate();
            ///Si la persona retornada es la misma que la que se ingreso 
            Assert.Equal(prueba,esperado);
        }






    }
}
