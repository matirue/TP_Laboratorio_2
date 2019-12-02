using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Campos

        private static SqlCommand comando;
        private static SqlConnection conexion;

        #endregion

        #region Metodos

        /// <summary>
        /// Inicia la conexion con la base de datos.
        /// </summary>
        static PaqueteDAO()
        {

            //Direccion de Base de datos segun las maquinas de laboratorio
            //string conneectSQL = @"Data Source=.\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security = True";

            //Direccion de Base de datos segun la maquina del alumno(Rueda, Matias Mauro), actualmetne configurado 
            //en las propiedades con el string Conexion
            //string conneectSQL = @"Data Source=DESKTOP-3N7LUOO; Initial Catalog=correo-sp-2017; Integrated Security = True";
            

            try
            {
                //conexion = new SqlConnection(conneectSQL);
                conexion = new SqlConnection(Properties.Settings.Default.Conexion);
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la conexion con la base de datos", ex);
            }
        }

        /// <summary>
        /// Se guarda un paquete en la base de datos
        /// </summary>
        /// <param name="p">paquete que se va a guardar en la base</param>
        /// <returns>True si salio todo bien. Si hay un error lanza una exception</returns>
        public static bool Insertar(Paquete p)
        {
            bool respuesta = false;
            try
            {
                string consulta = String.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) " +
                              "VALUES ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Reuda Matias Mauro");
                comando.CommandText = consulta;
                conexion.Open();
                comando.ExecuteNonQuery();
                respuesta = true;
            }
            catch (Exception ex)
            {
                string message = String.Format("Error al guardar el paquete {0} en la base de datos", p.ToString());
                throw new Exception(message, ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return respuesta;
        }

        #endregion
    }
}
