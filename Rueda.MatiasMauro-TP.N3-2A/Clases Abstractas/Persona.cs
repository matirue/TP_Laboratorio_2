using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerado
        /// <summary>
        /// Enumerado con las nacionalidades pedidas
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region Campos

        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        #endregion

        #region Propiedades

        public string Apellido
        {
            get { return this.apellido; }
            set { apellido = ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this.dni; }
            set{ dni = ValidarDni(nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { nombre = ValidarNombreApellido(value); }
        }

        public string StringToDNI 
        {
            set { dni = ValidarDni(Nacionalidad, value); }
        }
        #endregion

        #region Metodos

        #region Constructor

        /// <summary>
        /// Constructor de PERSONA
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor de PERSONA
        /// </summary>
        /// <param name="nombre">string de nombre</param>
        /// <param name="apellido">string de paellido</param>
        /// <param name="nacionalidad">ENacionalidad de nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de PERSONA
        /// </summary>
        /// <param name="nombre">string de nombre</param>
        /// <param name="apellido">string de paellido</param>
        /// <param name="dni">int de dni</param>
        /// <param name="nacionalidad">ENacionalidad de nacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) 
            : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de PERSONA
        /// </summary>
        /// <param name="nombre">string de nombre</param>
        /// <param name="apellido">string de paellido</param>
        /// <param name="dni">string de dni</param>
        /// <param name="nacionalidad">ENacionalidad de nacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        
        #endregion

        /// <summary>
        /// Retorna los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder x = new StringBuilder();
            x.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            x.AppendLine();
            x.AppendFormat("NACIONALIDAD: {0}", this.Nacionalidad);
            x.AppendLine();
            return x.ToString();
        }

        #region Validaciones

        /// <summary>
        /// Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. 
        /// Argentino entre 1 y 89999999 y Extranjero entre 90000000 y 99999999. 
        /// Caso contrario, se lanzará la excepción NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad">ENacionalidad de nacionalidad</param>
        /// <param name="dato">int de dato</param>
        /// <returns></returns>
        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            string message="La nacionalidad no se condice con el nùmero de DNI";
            if(dato > 0 && dato <= 99999999)
            {
                if (!nacionalidad.Equals(ENacionalidad.Argentino) && dato <= 89999999)
                {                    
                    throw new NacionalidadInvalidaException(message);
                }
                else if (!nacionalidad.Equals(ENacionalidad.Extranjero) && dato >= 90000000)
                {                    
                    throw new NacionalidadInvalidaException(message);
                }                
                else
                    return dato;
            }
            else
            {
                throw new DniInvalidoException("Valor Invalido para DNI");
            }
            
        }

        /// <summary>
        /// Si el DNI presenta un error de formato 
        /// (más caracteres de los permitidos, letras, etc.) se lanzará DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad">ENacionalidad de nacionalidad</param>
        /// <param name="dato">string de dato</param>
        /// <returns></returns>
        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int entero; ;

            if (dato.Length < 9)
            {
                try
                {
                    entero = Int32.Parse(dato);
                }
                catch (Exception e)
                {

                    throw new DniInvalidoException(e);
                }

                return ValidarDni(nacionalidad, entero);
            }
            else
                throw new DniInvalidoException("El valor excede el maxiomo de caracteres para el dni.");
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. 
        /// Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        string ValidarNombreApellido(string dato)
        {

            Match m = Regex.Match(dato, @"^[a-zA-ZáéíóúÁÉÍÓÚ '-]+$");
            if (m.Success)
                return dato;
            else
                throw new Exception("Nombre Invalido.");
        }
        #endregion

        #endregion
    }
}
