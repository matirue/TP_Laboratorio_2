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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

            string[] operadores = { "+", "-", "/", "*" };

            foreach(string op in operadores)
            {
                this.cmbOperador.Items.Add(op);
            }

            this.cmbOperador.Items.Add(" ");
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOperador.SelectedItem = ("+");

            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();

            lblResultado.Text = num.DecimalBinario(lblResultado.Text);

            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();

            lblResultado.Text = num.BinarioDecimal(lblResultado.Text);

            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }


        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)).ToString();

            btnConvertirABinario.Enabled = true;
            btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Limpia los texbox, el combobox y el label. Tambien bloquea los botones de Convertir a binario y Convertir a decimal
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.Text = " ";
            this.lblResultado.Text = "0";

            btnConvertirABinario.Enabled = false;
            btnConvertirABinario.Enabled = false;
        }


        /// <summary>
        /// Realiza la operacion solicitada por el usuario
        /// </summary>
        /// <param name="numero1">Primer numero</param>
        /// <param name="numero2">Segundo numero</param>
        /// <param name="operador">Operador solicitado</param>
        /// <returns>Retorna la solucion de la operacion.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }
    }
}
