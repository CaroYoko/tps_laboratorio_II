using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        int id;
               
        public Medico() : base()
        {

        }

        public Medico(string nombre, string apellido, string celular, string email, int dni, Especialidad especialidad)
          : base(nombre, apellido, celular, email, dni)
        {
            this.especialidad = especialidad;
        }

        [JsonConstructor]
        public Medico(int id, string nombre, string apellido, string celular, string email, int dni, Especialidad especialidad)
         : this(nombre, apellido, celular, email, dni, especialidad)
        {
            this.id = id;
          
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

        /// <summary>
        /// Agrega al listado de médicos
        /// </summary>
        public override void AgregarAListado()
        {
            MedicoDAO medicoDAO = new MedicoDAO();
            medicoDAO.Guardar(this);

        }

        /// <summary>
        /// Busca el medico por Dni
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>Medico</returns>
        /// <exception cref="NoEncontradoExcepcion"></exception>
        public static Medico BuscarMedicoPorDNI(int dni)
        {
            foreach (Medico medico in Clinica.ListadoMedicos)
            {
                if (medico.Dni == dni)
                {
                    return medico;
                }
            }

            throw new NoEncontradoExcepcion("Médico no registrado");

        }

        public static Medico BuscarMedicoPorId(int idMedico)
        {
            Medico auxMedicos = null;
            foreach (Medico medico in Clinica.ListadoMedicos)
            {
                if (medico.Id == idMedico)
                {
                    auxMedicos = medico;
                    break;
                }
            }
            return auxMedicos;

        }

        /// <summary>
        /// Filtra la lista de medicos segun su especialidad
        /// </summary>
        /// <param name="estado"></param>
        /// <returns> Retorna la lista filtrada</returns>
        public static List<Medico> FiltrarMedicoPorEspecialidad(Especialidad especialidad)
        {
            List<Medico> auxLista = new List<Medico>();

            foreach (Medico medico in Clinica.ListadoMedicos)
            {
                if (medico.Especialidad == especialidad)
                {
                    auxLista.Add(medico);
                }
            }

            return auxLista;
        }


    }

}
