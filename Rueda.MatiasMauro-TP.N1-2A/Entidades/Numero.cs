using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase con los metodos de la calculadora
    /// </summary>
    public class Numero
    {
        #region ATRIBUTO

        private double _numero;

        #endregion


        #region PROPIEDADES
        /// <summary>
        /// Asigna un valor al atributo _numero previa validación
        /// </summary>
        private string SetNumero
        {
            set
            {
                _numero = ValidarNumero(value);
            }
        }

        #endregion


        #region METODOS

        /// <summary>
        /// Convierte un numero de binario a decimal
        /// </summary>
        /// <param name="binario">String binario q recibe</param>
        /// <returns>Retorna el numero en decimal o mensaje de error en caso del que el valor pasado sea invalido </returns>
        public string BinarioDecimal(string binario)
        {
            bool flag = true;
            int[] cadEntero = new int[binario.Length];
            double numero = 0;
            string retorno= " ";

            for(int i = 0; i < binario.Length; i++)
            {
                cadEntero[i] = (int)char.GetNumericValue(binario[i]);
                if(cadEntero[i]!=0 && cadEntero[i] != 1)
                {
                    flag = false;
                    break;
                }
            }

            if (flag == true)
            {
                for(int i = 0; i < binario.Length; i++)
                {
                    numero += (cadEntero[i] * Math.Pow(2, binario.Length - i - 1));
                }

                retorno = numero.ToString();
            }
            else
            {
                retorno = "\nValor Invalido.\n";
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un decimal a binario
        /// </summary>
        /// <param name="numero">Double decimal que recibe</param>
        /// <returns>Retorna el numero en binario o mensaje de error en caso del que el valor pasado sea invalido</returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario( numero.ToString() );
        }

        /// <summary>
        /// Convierte un decimal a binario
        /// </summary>
        /// <param name="numero">String decimal que recibe</param>
        /// <returns>Retorna el numero en binario o mensaje de error en caso del que el valor pasado sea invalido</returns>
        public string DecimalBinario(string numero)
        {
            string retorno = " ";
            decimal num1;
            uint num2;

            if(Decimal.TryParse(numero,out num1))
            {
                if(UInt32.TryParse(numero,out num2))
                {
                    retorno = Convert.ToString(Convert.ToInt32(numero, 10), 2);
                }
                else
                {
                    retorno = "\nValor Invalido.\n";
                }
            }
            else
            {
                retorno = "\nValor Invalido.\n";
            }

            return retorno;
        }

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor por defecto que asigna 0 (cero) al atributo _numero
        /// </summary>
        public Numero():this(0)
        {
        }
        /// <summary>
        /// Constructor con parametro double para inicializar
        /// </summary>
        /// <param name="numero">Parametro double que recibe</param>
        public Numero(double numero):this(numero.ToString())
        {
        }
        /// <summary>
        /// Constructor con parametro string para inicializar
        /// </summary>
        /// <param name="strNumero">Parametro strin que recibe</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        #endregion

        #region SOBRECARGA

        /// <summary>
        /// Operador Sumar(+)
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }

        /// <summary>
        /// Operador Restar(-)
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }

        /// <summary>
        /// Operador Dividir (/)
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2._numero != 0)
            {
                return n1._numero / n2._numero;
            }
            else
            {
                return double.MinValue;
            }
        }

        /// <summary>
        /// Operador Multiplicar (*)
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

        #endregion

        /// <summary>
        /// Comprobará que el valor recibido sea numérico
        /// </summary>
        /// <param name="strNumero">string a validad</param>
        /// <returns>Retorna el valor en formato double, o 0 (cero) en caso de error</returns>
        private double ValidarNumero (string strNumero)
        {
            double retorno = 0;
            double numero;

            if(Double.TryParse(strNumero,out numero))
            {
                retorno = numero;
            }
            return retorno;

            
        }

        #endregion
    }
}
