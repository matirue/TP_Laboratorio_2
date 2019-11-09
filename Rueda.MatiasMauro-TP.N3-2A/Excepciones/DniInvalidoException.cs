using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Campos

        static string mensajeBase = "El DNI no es valido.";

        #endregion

        #region Metodos

        /// <summary>
        /// Emite mensaje: "El DNI no es valido."
        /// </summary>
        public DniInvalidoException() : base(mensajeBase) { }

        /// <summary>
        /// Emite mensaje: "El DNI no es valido.", junto a la excepcion
        /// </summary>
        public DniInvalidoException(Exception e) : base(mensajeBase, e) { }

        /// <summary>
        /// Emite mensaje que recibe como parametro
        /// </summary>
        public DniInvalidoException(string message) : base(message) { }

        /// <summary>
        /// Emite mensaje que recibe como parametro, junto a la excepcion
        /// </summary>
        public DniInvalidoException(string message, Exception e) : base(message, e) { }

        #endregion
    }
}
