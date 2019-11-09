using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;
using System.IO;


namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Implementacion de IArchivo
        /// <summary>
        /// Guarda los datos en un archivo .txt 
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se guardara</param>
        /// <param name="datos">Los datos que se guardaran</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = null; 

            try
            {
                sw = new StreamWriter(archivo);
                sw.WriteLine(datos);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);

            }
            finally
            {
                sw.Close();
            }
            
        }


        /// <summary>
        /// Lee un archivo .txt
        /// </summary>
        /// <param name="archivo">Ruta del archivo a leer.</param>
        /// <param name="datos">Los datos a leer</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr = null; 

            try
            {
                sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                sr.Close();
            }
        }
        #endregion
    }
}
