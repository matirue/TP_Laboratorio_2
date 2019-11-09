using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Campos

        Queue<Universidad.EClases> claseDelDia;
        static Random random;

        #endregion

        #region Metodos

        /// <summary>
        /// Toma dos clases de manera aleatoria y las pone en cola en claseDelDia.
        /// </summary>
        void _randomClases()
        {
            this.claseDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            this.claseDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }


        /// <summary>
        /// Muestra los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder x = new StringBuilder();

            x.Append(base.MostrarDatos());
            x.Append(ParticiparEnClase());

            return x.ToString();
        }

        #region Operadores

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if (i.claseDelDia.Contains(clase))
                return true;

            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion

        /// <summary>
        /// Muestra la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder x = new StringBuilder();

            x.AppendLine("CLASE DEL DIA: ");
            foreach (Universidad.EClases c in claseDelDia)
                x.AppendLine(c.ToString());

            return x.ToString();
        }


        #region Constructor

        /// <summary>
        /// Inicializa random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de profesor
        /// </summary>
        public Profesor() { }

        /// <summary>
        /// Cnstructor de profesor, inicializa la lista y genera dos clases aleatoria.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido,string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        /// <summary>
        /// Hará públicos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

    }
}
