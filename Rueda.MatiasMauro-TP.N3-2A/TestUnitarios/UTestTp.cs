using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace TestUnitarios
{
    [TestClass]
    public class UTestTp
    {
        #region Test 1
        /// test que crea un alumno dni valido
        [TestMethod]      
        public void TestMethod1()
        {
            Alumno a = new Alumno(1234, "nomA", "apeA", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Assert.AreEqual(12345678, a.DNI);
        }
        #endregion

        #region Test 2
        /// test que crea un alumno dni invalido
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestMethod2()
        {
            Alumno a = new Alumno(4321, "nomB", "apeB", "0", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            
        }
        #endregion

        #region Test 3
        /// test que crea un alumno extranjer con un dni menor
        [TestMethod]        
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestMethod3()
        {
            Alumno a = new Alumno(1234, "nomC", "apeC", "1234", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);

        }
        #endregion

        #region Test 4
        /// test que chequea jornada se qcargue en la universidad
        [TestMethod]
        public void TestMethod4()
        {
            Universidad u = new Universidad();
            Profesor p = new Profesor();
            Jornada j = new Jornada(Universidad.EClases.Programacion, p);

            u[0] = j;

            Assert.IsNotNull(u[0]);
            Assert.AreSame(j, u[0]);
        }
        #endregion

    }
}
