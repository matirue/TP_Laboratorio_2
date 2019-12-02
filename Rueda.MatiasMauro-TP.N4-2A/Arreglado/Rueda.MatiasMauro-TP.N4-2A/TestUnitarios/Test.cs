using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Verificar_ListaDePaquetesDelCorreoEstaInstanciada()
        {
            // Arrange
            Correo correo;
            // Act
            correo = new Correo();
            // Assert
            Assert.AreNotEqual(null, correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void Verificar_NoSePuedeCargarDosPaquetesConMismoTrackingIDEnUnCorreo()
        {
            // Arrange
            Correo correo = new Correo();
            Paquete paq1 = new Paquete("qwe", "123");
            Paquete paq2 = new Paquete("asd", "456");
            // Act
            correo += paq1;
            correo += paq2;
        }
    }
}
