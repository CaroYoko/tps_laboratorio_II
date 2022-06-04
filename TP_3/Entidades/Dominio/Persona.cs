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
            this.nombre = nombre;
            this.apellido = apellido;
            this.celular = celular;
            this.email = email;
            this.dni = dni;
        }       

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public string Celular
        {
            get { return this.celular; }
            set { this.celular = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public int Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }
                
        public abstract void AgregarAListado();             

        public override string ToString()
        {
            return string.Format("{0} {1} ",this.Nombre, this.Apellido);
        }


    }
}
