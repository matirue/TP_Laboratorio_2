using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {

        Correo correo;


        public FrmPpal()
        {
            InitializeComponent();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            try
            {
                correo += paquete;
                paquete.InformaEstado += paq_InformaEstado;
                paquete.InformaSQLException += InfoSQLException;
                ActualizarEstados();
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message, "Paquete Repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }




        /// <summary>
        /// Actualiza los listBox con los paquetes
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }

        /// <summary>
        /// Controla que el atributo del elemento no sea nulo y lo muestra.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                string datos = elemento.MostrarDatos(elemento); ;

                rtbMostrar.Text = datos;
                try
                {
                    datos.Guardar(@"salida.txt");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "NO se guardo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Muestra la informacion de un paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Informa del estado de los paquetes del correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Muestra el error si se produjo un fallo con la base de datos.
        /// </summary>
        /// <param name="e"></param>
        private void InfoSQLException(Exception ex)
        {
            MessageBox.Show(ex.Message, "NO se guardo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// cierra todos los hilos abiertos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void FrmPpal_Load_1(object sender, EventArgs e)
        {
            correo = new Correo();
        }
    }
}
