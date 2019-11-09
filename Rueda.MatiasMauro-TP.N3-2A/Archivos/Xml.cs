using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Implementacion de IArchivo

        /// <summary>
        /// Guarda los datos en un archivo .xml 
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se guardara</param>
        /// <param name="datos">Los datos que se guardaran</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {

            //TextWriter tw = new StreamWriter(archivo);
            XmlTextWriter tw = null; 
            XmlSerializer xSer = null; 
            try
            {
                tw = new XmlTextWriter(archivo, Encoding.UTF8);
                xSer = new XmlSerializer(typeof(T));
                xSer.Serialize(tw, datos);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                tw.Close();
            }
          
        }


        /// <summary>
        /// Lee un  archivo de .xml 
        /// </summary>
        /// <param name="archivo">Ruta del archivo a leer.</param>
        /// <param name="datos">Los datos a leer</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            //TextReader tr = new StreamReader(archivo);
            XmlTextReader tr = null; 
            XmlSerializer xSer = null;
            try
            {
                tr = new XmlTextReader(archivo);
                xSer = new XmlSerializer(typeof(T));
                datos = (T)xSer.Deserialize(tr);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                tr.Close();
            }
        }
        #endregion
    }
}
