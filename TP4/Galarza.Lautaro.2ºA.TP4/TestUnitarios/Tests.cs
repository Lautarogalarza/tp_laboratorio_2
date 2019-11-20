using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void PaqueteRepetidoTest()
        {

            Paquete pruebaPaquete1 = new Paquete("Mitre 750", "1231231234");
            Paquete pruebaPaquete2 = new Paquete("Belgrano 1060", "1231231234");
            Correo pruebaCorreo = new Correo();
            pruebaCorreo += pruebaPaquete1;

            try
            {
                pruebaCorreo += pruebaPaquete2;
                Assert.Fail();

            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }

        }

        [TestMethod]
        public void ListaInstanciadaTest()
        {
            Correo pruebaCorreo = new Correo();
            Assert.IsNotNull(pruebaCorreo.Paquetes);
        }
    }
}
