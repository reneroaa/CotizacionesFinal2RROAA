using System;
using Xunit; 
using Cotizaciones.Models;
//using CotizacionesFinal2RROAA.

namespace CotizacionesFinal2RROAAtesting
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
        }

        public void retornarExcepcionPorGuionVerificador()
        {
            var result = new Persona();
            result.Rut = "89938627";

            Exception ex = Assert.Throws<ArgumentException>(() => result.validate());

            Assert.Equal("RUT no valido", ex.Message);
        }

         public void retornarPersonaPorRutCorrecto()
        {
            var prueba = new Persona();
            prueba.Rut = "8993862-7";
            var esperado = new Persona();
            esperado = prueba.validate();
            ///Si la persona retornada es la misma que la que se ingreso 
            Assert.Equal(prueba,esperado);
        }

    }
}
