using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        #region Enumerados

        public enum EEstado
        {
            Ingresado, 
            EnViaje,
            Entregado
        }

        #endregion

        #region Delegados-Eventos

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoSQLException(Exception e);
        public event DelegadoEstado InformaEstado;
        public event DelegadoSQLException InformaSQLException;

        #endregion

        #region Campos

        string direccionEntrega;
        EEstado estado;
        string trackingID;

        #endregion

        #region Propoiedades

        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        #endregion

        #region Metodos
        
        /// <summary>
        /// Hace quel paquete cambie de estado cada 4 segundos, informando el estado           
        /// </summary>
        public void MockCicloDeVida()
        {
            while (Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                Estado += 1;
                InformaEstado(this, null);
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {
                InformaSQLException(ex);
            }
        }

        //implementacion del IMostrar
        /// <summary>
        /// Compila la informacion mostrandola con el formato pedido
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).TrackingID, 
                                                 ((Paquete)elemento).DireccionEntrega);
        }

        #region Operadores

        /// <summary>
        /// Dos paquetes seran iguales cuando los TrackingId dean el mismo 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID.Equals(p2.TrackingID);
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        
        #endregion

        #region Constructores

        public Paquete(string direccionEntrega, string trackingID)
        {
            DireccionEntrega = direccionEntrega;
            TrackingID = trackingID;
            Estado = EEstado.Ingresado;
        }

        #endregion

        /// <summary>
        /// Sobrecarga que retorna la informacion del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion


    }
}
