using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Campos

        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #endregion

        #region Propiedades

        public List<Alumno>  Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instrtuctor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            return new Texto().Guardar("Jornada.txt", jornada.ToString());
        }

        #region Constructor

        /// <summary>
        /// Constructor que inicializa la lista alumnos.
        /// </summary>
        Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de jornada.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        /// <summary>
        /// Retornará los datos de la Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string ret = " ";
            new Texto().Leer("Jornada.txt", out ret);
            return ret;
        }

        #region Operadores
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach(Alumno al in j.Alumnos)
            {
                if (al == a)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
                return j;
            }

            throw new AlumnoRepetidoException();
        }
        #endregion

        /// <summary>
        /// Mostrará todos los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder x = new StringBuilder();
            x.AppendFormat("CLASE DE {0} POR ", this.Clase);
            x.AppendLine(Instrtuctor.ToString());
            x.AppendFormat("ALUMNOS: ");
            foreach(Alumno a in this.Alumnos)
            {
                x.AppendLine(a.ToString());
            }

            return x.ToString();
        }
        #endregion
    }
}
