using Entidades.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum ETipoExtension
    {
        Json,
        Xml
    }

    public static class Clinica
    {
        private static List<Turno> listadoTurnosHoy;


        static Clinica()
        {
            Clinica.ListadoTurnosHoy = new List<Turno>();
        }

        public static List<Paciente> ListadoPacientes
        {
            get
            {
                PacienteDAO pacienteDAO = new PacienteDAO();
                return pacienteDAO.Leer();
            }
        }

        public static List<Turno> ListadoTurnos
        {
            get
            {
                try
                {
                    TurnoDAO turnoDAO = new TurnoDAO();
                    return turnoDAO.Leer();
                }
                catch(ErrorLecturaException ex) {

                    throw ex;
                }

            }
        }

        public static List<Medico> ListadoMedicos
        {
            get
            {
                MedicoDAO medicoDAO = new MedicoDAO();
                return medicoDAO.Leer();
            }
        }

        public static List<Turno> ListadoTurnosHoy { get => listadoTurnosHoy; set => listadoTurnosHoy = value; }


        /// <summary>
        /// Importa archivos Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="archivo"></param>
        public static void Importar<T>(string archivo) where T : class, IListable
        {

            List<T> auxLista = new List<T>();

            auxLista = ArchivosJson<List<T>>.Leer(archivo, AppDomain.CurrentDomain.BaseDirectory);

            auxLista.AgregarListado();


        }


        /// <summary>
        /// Metodo generico que agrega al listado de la clinica
        /// que corresponda segun su tipo de dato
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista"></param>
        public static void AgregarListado<T>(List<T> lista) where T : class, IListable
        {
            try
            {
                if (lista is not null)
                {
                    foreach (T item in lista)
                    {
                        item.AgregarAListado();
                    }
                }
            }
            catch (NoEncontradoExcepcion ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Filtra la lista de turnos segun fecha y dni del paciente.
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="dni"></param>
        /// <returns> Si se utiliza el primer parametro, devuelve la lista con todos los turnos de la fecha </returns>
        /// <returns> Si se utiliza el primer y segundo parametro, devuelve la lista con todos los turnos de la fecha de ese dni de paciente </returns>
        public static List<Turno> BuscarTurno(DateTime fecha, int dni = 0)
        {
            try {

                List<Turno> lista = new List<Turno>();

                foreach (Turno turno in Clinica.ListadoTurnos)
                {
                    if (fecha.Date == turno.FechaYHora.Date && (dni == 0 || dni == turno.Paciente.Dni))
                    {
                        lista.Add(turno);
                    }
                }
                return lista;
            }
            catch (ErrorLecturaException ex) {
                throw ex;
            }


        }

        public static void Notificar(DateTime fechaANotificar)
        {
            List<Turno> listadoTurnos = Clinica.BuscarTurno(fechaANotificar);
            listadoTurnos.ForEach(turno =>
            {
                turno.RecibirNotificacion();
            });

        }

    }


}
