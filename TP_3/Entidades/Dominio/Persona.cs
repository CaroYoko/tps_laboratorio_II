using System;
using System.Text;

namespace Entidades
{
    public abstract class Persona : IListable
    {

        string nombre;
        string apellido;
        string celular;
        string email;
        int dni;

        public Persona()
        {


        }

        public Persona(string nombre, string apellido, string celular, string email, int dni) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Celular = celular;
            this.Email = email;
            this.Dni = dni;
        }

        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                if (Validaciones.EsNombreApellidoValido(value))
                {
                    this.nombre = value;
                }
                else
                {
                    throw new ArgumentoNoValidoException("Nombre no válido");
                }
            }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                if (Validaciones.EsNombreApellidoValido(value))
                {
                    this.apellido = value;
                }
                else
                {
                    throw new ArgumentoNoValidoException("Apellido no válido");
                }

            }
        }

        public string Celular
        {
            get { return this.celular; }
            set
            {
                if (Validaciones.EsCelularValido(value))
                {
                    this.celular = value;
                }
                else
                {
                    throw new ArgumentoNoValidoException("Número de celular no válido");
                }

            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (Validaciones.EsMailValido(value))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentoNoValidoException("Email no válido");
                }

            }
        }

        public int Dni
        {
            get { return this.dni; }
            set
            {
                if (Validaciones.EsDNIValido(value))
                {
                    this.dni = value;
                }
                else
                {
                    throw new ArgumentoNoValidoException("DNI no válido");
                }

            }
        }

        public abstract void AgregarAListado();

        /// <summary>
        /// Sobreescribe el ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} ", this.Nombre, this.Apellido);
        }


    }
}
