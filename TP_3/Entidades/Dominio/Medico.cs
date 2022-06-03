using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Especialidad
    {
        Clínico, Gastroenterología, Cardiología, Pediatría, Nutrición, Neurología
    }
    public class Medico : Persona
    {
        Especialidad especialidad;
        Random random = new Random();
        static int ultimoId;
        int id;


        static Medico()
        {
            Medico.ultimoId = 1;
        }

        public Medico() : base()
        {            
            this.id = Medico.ultimoId;
            Medico.ultimoId++;
        }

        public Medico(string nombre, string apellido, string celular, string email, int dni, Especialidad especialidad)
          : base(nombre, apellido, celular, email, dni)
        {
            this.especialidad = especialidad;
        }

        public int Id
        {
            get { return this.id; }
        }

        public Especialidad Especialidad
        {
            get { return this.especialidad; }
            set { this.especialidad = value; }
        }

        public override void AgregarAListado()
        {
            Clinica.listadoMedico.Add(this);
        }

        public static Medico BuscarMedicoPorDNI(int dni)
        {
            foreach (Medico medico in Clinica.listadoMedico)
            {
                if (medico.Dni == dni)
                {
                    return medico;
                }
            }

            throw new NoExisteException("Médico no registrado");

        }




    }

}
