using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente : Persona
    {
        public enum EObraSocial { 

            UNIONPERSONAL, OSDE, PASTEUR, SWISSMEDICAL, GALENO       

        }
       
        EObraSocial obraSocial;        
        static int ultimoId;
        int id;

        
        static Paciente()
        {
            Paciente.ultimoId = 1;
        }
        

        public Paciente() : base()
        {
        }

        public Paciente(string nombre, string apellido, string celular, string email, int dni, EObraSocial obraSocial) : base(nombre, apellido, celular, email, dni)
        {
            this.obraSocial = obraSocial;
            this.id = Paciente.ultimoId;
            Paciente.ultimoId++;
            
        }

        [JsonConstructor]
        public Paciente(int id, string nombre, string apellido, string celular, string email, int dni, EObraSocial obraSocial) : base (nombre, apellido, celular, email, dni)
        {
            this.id = id;
            this.obraSocial = obraSocial;

            if (Paciente.ultimoId <= id) {

                Paciente.ultimoId = id + 1;
            }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }        
        }

        public EObraSocial ObraSocial
        {
            get { return this.obraSocial; }
            set { this.obraSocial = value; }        
        }

        public static Paciente BuscarPacientePorDNI(int dniPaciente)
        {            
            foreach (Paciente paciente in Clinica.listadoPacientes)
            {
                if (paciente.Dni == dniPaciente)
                {
                    return paciente;                    
                }
            }

            throw new NoExisteException("Paciente no registrados");           

        }

        public static Paciente BuscarPacientePorId(int idPaciente)
        {
            Paciente auxPaciente = null;
            foreach (Paciente paciente in Clinica.listadoPacientes)
            {
                if (paciente.Id == idPaciente)
                {
                    auxPaciente = paciente;
                    break;
                }
            }
            return auxPaciente;

        }

        public override void AgregarAListado()
        {
            Clinica.listadoPacientes.Add(this);
        }

        public static bool BorrarPaciente(Paciente paciente) {                      

            if (paciente is not null) { 
            
                Clinica.listadoPacientes.Remove(paciente);
                return true;
            }
            return false;

        }

       
    }
}
