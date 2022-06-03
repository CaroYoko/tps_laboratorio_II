﻿using System;
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


        public static void Importar<T>(string archivo) where T : class, IListable
        {
            List<T> auxLista = new List<T>();

            auxLista = ArchivosJson<List<T>>.Leer(archivo, AppDomain.CurrentDomain.BaseDirectory);

            AgregarListado(auxLista);
        }



        public static void AgregarListado<T>(List<T> lista) where T : class, IListable
        {
            if (lista is not null)
            {
                foreach (T item in lista)
                {
                    item.AgregarAListado();
                }
            }
        }

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
