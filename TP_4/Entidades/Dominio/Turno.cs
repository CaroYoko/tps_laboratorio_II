using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno : IListable
    {
        public enum Estado
        {
            Pendiente, Espera, Ausente, Atendido, Todos
        }

       
        int id;
        DateTime fechaYHora;
        Paciente paciente;
        Medico medico;
        Estado estadoTurno;
        bool recordatorioNotificado;
        public Turno()
        {
            this.estadoTurno = Estado.Pendiente;           
        }

        public Turno(DateTime fechaYHora, Paciente paciente, Medico medico) : this() 
        { 
            this.fechaYHora = fechaYHora;
            this.paciente = paciente;
            this.medico = medico;
            this.RecordatorioNotificado = false;


        }
        
        [JsonConstructor]
        public Turno(int id, DateTime fechaYHora, Paciente paciente, Medico medico, bool recordatorioNotificado) : this(fechaYHora, paciente, medico)
        {
            this.id = id;
            this.RecordatorioNotificado = recordatorioNotificado;

        }        

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public Paciente Paciente
        {
            get { return this.paciente; }
            set { this.paciente = value; }
        }
        public Medico Medico
        {
            get { return this.medico; }
            set { this.medico = value; }
        }

        public DateTime FechaYHora
        {
            get { return this.fechaYHora; }
            set { this.fechaYHora = value; }
        }

        public Estado EstadoTurno
        {
            get { return this.estadoTurno; }
            set { this.estadoTurno = value; }
        }

        public bool RecordatorioNotificado { get => recordatorioNotificado; set => recordatorioNotificado = value; }


        public void RecibirNotificacion() {
            this.RecordatorioNotificado = true;
            TurnoDAO turnoDAO = new TurnoDAO();
            turnoDAO.ActualizarRecordatorio(this);

        }
        /// <summary>
        /// Valida si el medico tiene diponibilidad de atencion en un día y horario determinado
        /// </summary>
        /// <param name="medico"></param>
        /// <param name="fechaYHora"></param>
        /// <returns>true si esta disponible, sino false</returns>
        public static bool ValidarMedicoDisponible(Medico medico, DateTime fechaYHora)
        {
            foreach (Turno turno in Clinica.ListadoTurnos)
            {
                if (turno.medico.Id == medico.Id && turno.fechaYHora == fechaYHora)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Valida si el cliente puede atenderse en el dia y horario determinado
        /// </summary>
        /// <param name="paciente"></param>
        /// <param name="fechaYHora"></param>
        /// <returns>true si puede atenderse, sino false</returns>
        public static bool ValidarPacienteDisponible(Paciente paciente, DateTime fechaYHora)
        {
            List<Turno> lista = Clinica.ListadoTurnos;

            foreach (Turno turno in lista)
            {
                if (turno.paciente.Id == paciente.Id && turno.fechaYHora == fechaYHora)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Busca el turno con el ID indicado
        /// </summary>
        /// <param name="auxId"></param>
        /// <returns>Retorna el Turno buscado</returns>
        public static Turno BuscarTurnoPorId(int auxId)
        {
            Turno retorno = null;
            foreach (Turno turno in Clinica.ListadoTurnos)
            {
                if (turno.Id == auxId)
                {
                    retorno = turno;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Filtra la lista de turnos del día de la fecha segun su estado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns> Retrorna la lista filtrada</returns>
        public static List<Turno> FiltrarPorEstado(Estado estado)
        {
            try
            {
                List<Turno> listadoTurnos = Clinica.BuscarTurno(DateTime.Now.Date);

                List<Turno> auxLista = listadoTurnos.Where((turno) => estado == Turno.Estado.Todos || turno.EstadoTurno == estado).Cast<Turno>().ToList();

                return auxLista;

            }
            catch (ErrorLecturaException ex) {

                throw ex;
            
            }
        }

        /// <summary>
        /// Agrega al listado de turnos general
        /// </summary>
        /// <exception cref="NoDisponibleException"></exception>
        public void AgregarAListado()
        { 
            TurnoDAO turnoDAO = new TurnoDAO();

            if (Turno.ValidarPacienteDisponible(this.Paciente, this.FechaYHora) && Turno.ValidarMedicoDisponible(this.Medico, this.FechaYHora))
            {                
                turnoDAO.Guardar(this);
            }
            else
            {
                throw new NoEncontradoExcepcion("No es posible guardar el turno");
            }
        }

        /// <summary>
        /// Saca de la lista de turnos el turno pasado por parámetro
        /// </summary>
        /// <param name="turnoSeleccion"></param>
        /// <returns>true si se logró, sino false</returns>
        public static bool BorrarTurno(Turno turnoSeleccion)
        {
            if (turnoSeleccion is not null)
            {
                TurnoDAO turnoDAO = new TurnoDAO();
                turnoDAO.Eliminar(turnoSeleccion.Id);
                return true;
            }
            return false;
        }
             

       
    }
}
