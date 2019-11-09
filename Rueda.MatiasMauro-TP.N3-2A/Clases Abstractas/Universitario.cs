using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos

        int legajo;

        #endregion

        #region Metodos

        /// <summary>
        /// Compara si el objeto es de tipo Universitario
        /// </summary>
        /// <param name="obj">obj de tipo Object</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
                return true;
            else
                return false;
        } 

        /// <summary>
        /// Retorna todos los datos de Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder x = new StringBuilder();
            x.Append(base.ToString());
            x.AppendFormat("LEGAJO NUMERO: {0}", this.legajo);
            x.AppendLine();

            return x.ToString();
        }

        #region Operadores

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">objeto de tipo universitario</param>
        /// <param name="pg2">objeto de tipo universitario</param>
        /// <returns></returns>
        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            if (!Object.Equals(pg1, null) && !Object.Equals(pg2, null))
            {
                if (pg1.GetType().Equals(pg2.GetType()) && (pg1.legajo.Equals(pg2.legajo) || pg1.DNI.Equals(pg2.DNI)))
                    return true;
            }
            
            return false;
        }

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">objeto de tipo universitario</param>
        /// <param name="pg2">objeto de tipo universitario</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

        /// <summary>
        /// Metodo protegido y abtracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #region Constructores

        public Universitario() { }

        /// <summary>
        /// Constructor de universitario
        /// </summary>
        /// <param name="legajo">int de legajo</param>
        /// <param name="nombre">string de nombre</param>
        /// <param name="apellido">string de apellido</param>
        /// <param name="dni">string de dni</param>
        /// <param name="nacionalidad">ENAcionalidad de nacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion
               
        #endregion
    }
}
