using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        #region Metodos

        /// <summary>
        /// Guarda los datos en un archivo.
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se guardara</param>
        /// <param name="datos">Los datos que se guardaran</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Leer datos a leer.
        /// </summary>
        /// <param name="archivo">Ruta del archivo a leer.</param>
        /// <param name="datos">Los datos a leer</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);

        #endregion

    }
}
