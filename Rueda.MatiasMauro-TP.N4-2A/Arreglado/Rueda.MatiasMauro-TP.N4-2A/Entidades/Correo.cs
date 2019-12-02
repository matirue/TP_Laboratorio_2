using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        #region Campos

        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        #endregion

        #region Propiedades

        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        #endregion

        #region Metodos

        #region Constructor

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }

        #endregion

        /// <summary>
        /// Cierra todos los hilos.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread h in mockPaquetes)
            {
                if (h.IsAlive)
                    h.Abort();
            }
        }

        //implementacion del IMostrar
        /// <summary>
        /// Muestra la información del correo.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in ((Correo)elementos).Paquetes)
            {
                sb.AppendFormat("{0} ({1})", p.ToString(), p.Estado.ToString());
                sb.AppendLine();
            }


            return sb.ToString();
        }

        #region Operadores

        /// <summary>
        /// Controla si el paquete ya esta en la lista.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (p == paquete)
                {
                    string message = String.Format("El trackingID {0} esta en la lista de envios", p.TrackingID);
                    throw new TrackingIdRepetidoException(message);
                }
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();
            return c;
        }

        #endregion

        #endregion
    }
}
