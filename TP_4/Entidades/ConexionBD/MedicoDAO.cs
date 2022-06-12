using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades
{
    public class MedicoDAO
    {
        private static string connectionString;
        private SqlConnection connection;
        private SqlCommand command;


        static MedicoDAO()
        {
            connectionString = @"Server=.\SQLEXPRESS;Database=ClinicaBD; Trusted_Connection=True;";

        }
        public MedicoDAO()
        {
            connection = new SqlConnection(MedicoDAO.connectionString);
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

        }

        public void Guardar(Medico medico)
        {

            try
            {
                connection.Open();

                string query = "INSERT INTO Pacientes (nombre,apellido,celular,email,dni,obraSocial) VALUES (@nombre, @apellido, @celular, @email, @dni, @especialidad)";

                command.CommandText = query;

                command.Parameters.Clear();
                               
                command.Parameters.AddWithValue("nombre", medico.Nombre);
                command.Parameters.AddWithValue("apellido", medico.Apellido);
                command.Parameters.AddWithValue("celular", medico.Celular);
                command.Parameters.AddWithValue("email", medico.Email);
                command.Parameters.AddWithValue("dni", medico.Dni);
                command.Parameters.AddWithValue("especialidad", medico.Especialidad);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public List<Medico> Leer()
        {
            List<Medico> lista = new List<Medico>();
            try
            {
                string query = "SELECT * FROM Medicos";
                connection.Open();
                command.CommandText = query;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32(0);
                    string nombre = dataReader.GetString(1);
                    string apellido = dataReader.GetString(2);
                    string celular = dataReader.GetString(3);
                    string email = dataReader.GetString(4);
                    int dni = dataReader.GetInt32(5);
                    int especialidad = dataReader.GetInt32(6);

                    Medico medico = new Medico(id, nombre, apellido, celular, email, dni, (Especialidad)especialidad);

                    lista.Add(medico);
                }
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }
    }
}