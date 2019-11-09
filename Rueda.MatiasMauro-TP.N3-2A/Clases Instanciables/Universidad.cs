using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]

    public class Universidad
    {
        #region Enumerado
        /// <summary>
        /// Enumerado con las Clases pedidas
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #endregion

        #region Campos
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;
        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }


        /// <summary>
        /// Busca o agreaga una jornada segun su indice.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < Jornadas.Count)
                    return jornada[i];

                return null;
            }
            set
            {
                if (i >= 0 && i < Jornadas.Count)
                    jornada[i] = value;
                else if (i == Jornadas.Count)
                    jornada.Add(value);
                
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Guardar de clase serializará los datos del Universidad en un XML,
        /// incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            return ( new Xml<Universidad>().Guardar("Universidad.xml",uni) );
        }

        /// <summary>
        /// Leer de clase retornará un Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad uni;
            new Xml<Universidad>().Leer("Universidad.xml", out uni);
            return uni;
        }


        /// <summary>
        /// Retorna los datos de Universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        string MostrarDatos(Universidad uni)
        {
            StringBuilder x = new StringBuilder();
            foreach(Jornada j in Jornadas)
            {
                x.Append(j.ToString());
                x.AppendLine("<------------------------------------------------>");
            }

            return x.ToString();
        }

        #region Operadores

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Alumno al in g.alumnos)
            {
                if (al == a)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor p in g.Instructores)
            {
                if (p == i)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el 
        /// primer Profesor capaz de dar esa clase. Sino, lanzará la Excepción SinProfesorException. 
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p == clase)
                    return p;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.profesores)
            {
                if (p == clase)
                    return p;
            }
            return null;
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada
        /// indicando la clase, un Profesor que pueda darla (según su atributo ClasesDelDia)
        /// y la lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma).
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = (g == clase);
            Jornada j = new Jornada(clase, p);
            foreach(Alumno a in g.alumnos)
            {
                if (a == clase)
                    j.Alumnos.Add(a);
            }

            g.Jornadas.Add(j);

            return g;
        }
        /// <summary>
        /// Si al querer agregar alumnos este ya figura en la lista, lanzar la excepción AlumnoRepetidoException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }
        /// <summary>
        /// Se agregarán Profesores mediante el operador +, validando que no estén previamente cargados.    
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);

            return u;
        }
        #endregion


        /// <summary>
        /// Mustra los datos de Universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #region Constructor

        /// <summary>
        /// Constructor de universidad.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
            
        }

        #endregion

        #endregion
    }
}
