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
        public static List<Paciente> listadoPacientes;
        public static List<Turno> listadoTurnos;
        public static List<Medico> listadoMedico;
        public static List<Turno> listadoTurnosHoy;

        static Clinica()
        {
            Clinica.listadoPacientes = new List<Paciente>();
            Clinica.listadoTurnos = new List<Turno>();
            Clinica.listadoMedico = new List<Medico>();
            Clinica.listadoTurnosHoy = new List<Turno>();

        }

        /// <summary>
        /// Importa archivos Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="archivo"></param>
        public static void Importar<T>(string archivo) where T : class, IListable
        {
            try
            {
                List<T> auxLista = new List<T>();

                auxLista = ArchivosJson<List<T>>.Leer(archivo, AppDomain.CurrentDomain.BaseDirectory);

                AgregarListado(auxLista);
            }
            catch (NoEncontradoExcepcion ex)
            {
                throw ex;
            }

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
            List<Turno> lista = new List<Turno>();

            foreach (Turno turno in Clinica.listadoTurnos)
            {
                if (fecha.Date == turno.FechaYHora.Date && (dni == 0 || dni == turno.Paciente.Dni))
                {
                    lista.Add(turno);
                }
            }

            return lista;

        }

    }


}
