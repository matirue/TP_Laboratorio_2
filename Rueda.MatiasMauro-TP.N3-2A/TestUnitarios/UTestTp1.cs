using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace TestUnitarios
{
    [TestClass]
    public class UTestTp1
    {
        #region Test 1
        //Test con apellido invalido
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod1()
        {
            string apellido = "123";
            Alumno a = new Alumno(111, "nombre", apellido, "1234", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }
        #endregion

        #region Test 2
        //Test con apellido valido
        [TestMethod]
        public void TestMethod2()
        {
            string apellido = "apellido";
            Alumno a = new Alumno(111, "nombre", apellido, "1234", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.AreEqual(apellido, a.Apellido);
        }
        #endregion

    }
}
