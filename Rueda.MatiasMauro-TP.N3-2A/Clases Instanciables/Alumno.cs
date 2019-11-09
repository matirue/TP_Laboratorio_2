using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerado
        /// <summary>
        /// Enumerado con los Estados de cuenta pedidos 
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region Campos
        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;
        #endregion

        #region Metodos

        #region Constructor

        /// <summary>
        /// Constructor de alumno.
        /// </summary>
        public Alumno() { }

        /// <summary>
        /// Constructor de alumno.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de alumno.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this.estadoCuenta=estadoCuenta;
        }

        #endregion

        /// <summary>
        /// Muestra los datos de alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder x = new StringBuilder();
            x.Append(base.MostrarDatos());
            x.AppendFormat("\n ESTADO DE CUENTA: {0}", this.estadoCuenta);
            x.AppendFormat(this.ParticiparEnClase());

            return x.ToString();
        }

        #region Operadores

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">a de tipo Alumno</param>
        /// <param name="clase">clase de tipo EClase</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma.Equals(clase) && !a.estadoCuenta.Equals(EEstadoCuenta.Deudor))
                return true;

            return false;
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a">a de tipo Alumno</param>
        /// <param name="clase">clase de tipo EClase</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
           //return !(a == clase);
            return !a.claseQueToma.Equals(clase);
        }

        #endregion


        /// <summary>
        /// Muestra la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("\n TOMA CLASE DE: {0}", this.claseQueToma.ToString());
        }

        /// <summary>
        /// Hace publico los datos del alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
