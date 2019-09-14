using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase encargada de realizar la operacion de la calculadora.
    /// </summary>
    public class Calculadora
    {
        #region METODOS

        /// <summary>
        /// Realiza la operacion solicitada
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <param name="operador">Operador solicitado</param>
        /// <returns>Retorna el resultado de la operacion solicitada.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            switch( ValidarOperador(operador))
            {
                case "+":
                    retorno = num1 + num2;
                    break;

                case "-":
                    retorno = num1 - num2;
                    break;

                case "/":
                    retorno = num1 / num2;
                    break;

                case "*":
                    retorno = num1 * num2;
                    break;

                default:
                    retorno = num1 + num2;
                    break;
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el operador recibido sea +, -, / o *.
        /// </summary>
        /// <param name="operador">String Parametro recibido</param>
        /// <returns>Retorna el operador validado, caso contrario retornara +.</returns>
        private static string ValidarOperador(string operador)
        {
            if(operador=="+"|| operador == "-"|| operador == "/"|| operador == "*")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }

        #endregion


    }
}
