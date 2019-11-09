using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        #region Metodos
        /// <summary>
        /// Emite mensaje: "Alumno Repetido."
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno Repetido.") { }
        #endregion
    }
}
