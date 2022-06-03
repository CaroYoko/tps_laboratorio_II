﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno : IListable
    {
        public enum Estado
        {
            Pendiente, Espera, Ausente, Atendido, Todos
        }

        static int ultimoIdTurno;
        int idTurno;
        DateTime fechaYHora;
        Paciente paciente;
        Medico medico;
        Estado estadoTurno;

        public Turno()
        {
            this.estadoTurno = Estado.Pendiente;
            this.idTurno = Turno.ultimoIdTurno;
            Turno.ultimoIdTurno++;
        }
        static Turno()
        {
            Turno.ultimoIdTurno = 1;
        }

        public Turno(DateTime fechaYHora, Paciente paciente, Medico medico) : this()
        {
            this.fechaYHora = fechaYHora;
            this.paciente = paciente;
            this.medico = medico;            

        }             

        public int IdTurno
        {
            get { return this.idTurno; }
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

       

        /// <summary>
        /// Valida si el medico tiene diponibilidad de atencion en un día y horario determinado
        /// </summary>
        /// <param name="medico"></param>
        /// <param name="fechaYHora"></param>
        /// <returns>true si esta disponible, sino false</returns>
        public static bool ValidarMedicoDisponible(Medico medico, DateTime fechaYHora)
        {
            foreach (Turno turno in Clinica.listadoTurnos)
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
        public static bool ValidarClienteDisponible(Paciente paciente, DateTime fechaYHora)
        {
            foreach (Turno turno in Clinica.listadoTurnos)
            {
                if (turno.paciente.Id == paciente.Id && turno.fechaYHora == fechaYHora)
                {
                    return false;
                }
            }
            return true;
        }

        public static Turno BuscarTurnoPorId(int auxId)
        {
            Turno retorno = null;
            foreach (Turno turno in Clinica.listadoTurnos)
            {
                if (turno.IdTurno == auxId) {
                    retorno =  turno;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Filtra la lista de turnos del día de la fecha segun su estado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns> Retrorn la lista filtrada</returns>
        public static List<Turno> FiltrarPorEstado(Estado estado) {

            List<Turno> auxLista = new List<Turno>();

            foreach (Turno turno in Clinica.BuscarTurno(DateTime.Now.Date))
            {
                if (turno.EstadoTurno == estado)
                {
                    auxLista.Add(turno);
                }
            }
            if (estado == Turno.Estado.Todos) {
                auxLista = Clinica.BuscarTurno(DateTime.Now.Date);
            }

            return auxLista;
        }

        /// <summary>
        /// Agrega al listado de turnos general
        /// </summary>
        /// <exception cref="NoDisponibleException"></exception>
        public void AgregarAListado()
        {
            if (Turno.ValidarClienteDisponible(this.Paciente, this.FechaYHora) && Turno.ValidarMedicoDisponible(this.Medico, this.FechaYHora))
            {
                Clinica.listadoTurnos.Add(this);
            }
            else
            {
                throw new NoDisponibleException("No es posible guardar el turno");
            }
        }



    }
}
