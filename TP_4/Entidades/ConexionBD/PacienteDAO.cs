using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PacienteDAO
    {
        private static string connectionString;
        private SqlConnection connection;
        private SqlCommand command;


        static PacienteDAO()
        {
            connectionString = @"Server=.\SQLEXPRESS;Database=ClinicaBD; Trusted_Connection=True;";

        }
        public PacienteDAO()
        {
            connection = new SqlConnection(PacienteDAO.connectionString);
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

        }

        public void Guardar(Paciente paciente)
        {

            try
            {
                connection.Open();

                string query = "INSERT INTO Pacientes (nombre,apellido,celular,email,dni,obraSocial) VALUES (@nombre, @apellido, @celular, @email, @dni, @obraSocial)";

                command.CommandText = query;

                command.Parameters.Clear();
                
                
                command.Parameters.AddWithValue("nombre", paciente.Nombre);
                command.Parameters.AddWithValue("apellido", paciente.Apellido);
                command.Parameters.AddWithValue("celular", paciente.Celular);
                command.Parameters.AddWithValue("email", paciente.Email);
                command.Parameters.AddWithValue("dni", paciente.Dni);
                command.Parameters.AddWithValue("obraSocial", paciente.ObraSocial);

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
        public List<Paciente> Leer()
        {
            List<Paciente> lista = new List<Paciente>();
            try
            {
                string query = "SELECT * FROM Pacientes";
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
                    int obraSocial = dataReader.GetInt32(6);

                    Paciente paciente = new Paciente(id, nombre, apellido, celular, email, dni, (Paciente.EObraSocial)obraSocial);

                    lista.Add(paciente);
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

        public void Eliminar(int id)
        {
            try
            {
                string query = "DELETE FROM Pacientes WHERE id_Paciente = @idBuscado";

                connection.Open();

                command.CommandText = query;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("idBuscado", id);

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


    }
}
