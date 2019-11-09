using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region Metodos
        /// <summary>
        /// Emite mensaje: "La nacionalidad no es valida."
        /// </summary>
        public NacionalidadInvalidaException():base("La nacionalidad no es valida.") { }

        /// <summary>
        /// Emite mensaje que recibe por parametro
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message) { }

        #endregion
    }
}
