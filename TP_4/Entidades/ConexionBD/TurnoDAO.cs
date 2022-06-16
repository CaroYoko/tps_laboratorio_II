using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TurnoDAO
    {
        
        private static string connectionString;
        private SqlConnection connection;
        private SqlCommand command;

        static TurnoDAO()
        {
            connectionString = @"Server=.\SQLEXPRESS;Database=ClinicaBD; Trusted_Connection=True;";

        }
        public TurnoDAO()
        {
            connection = new SqlConnection(TurnoDAO.connectionString);
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

        }

        public void Guardar(Turno turno)
        {

            try
            {
                connection.Open();

                string query = "INSERT INTO Turnos (id_Medico,id_Paciente,fecha_Hora, recordatorioNotificado) VALUES (@id_Medico, @id_Paciente, @fecha_Hora, @recordatorioNotificado)";

                command.CommandText = query;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("id_Medico", turno.Medico.Id);
                command.Parameters.AddWithValue("id_Paciente", turno.Paciente.Id);
                command.Parameters.AddWithValue("fecha_Hora", turno.FechaYHora);
                command.Parameters.AddWithValue("recordatorioNotificado", turno.RecordatorioNotificado);

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


        public void ActualizarRecordatorio(Turno turno) {

            try {             
            
                connection.Open();

                string query = "UPDATE Turnos SET recordatorioNotificado = @recordatorioNotificado WHERE id_Turno = @id_Turno";

                command.CommandText = query;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("id_Turno", turno.Id);
                command.Parameters.AddWithValue("recordatorioNotificado", turno.RecordatorioNotificado);

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

        public List<Turno> Leer()
        {
            List<Turno> lista = new List<Turno>();
            try
            {
                string query = "SELECT * FROM Turnos";
                connection.Open();
                command.CommandText = query;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32(0);
                    int medico = dataReader.GetInt32(1);
                    int paciente = dataReader.GetInt32(2);
                    DateTime fecha_hora = dataReader.GetDateTime(3);
                    int recordatorioNotificado = dataReader.GetInt32(4);

                    Turno turno = new Turno(id, fecha_hora, Paciente.BuscarPacientePorId(paciente), Medico.BuscarMedicoPorId(medico), recordatorioNotificado == 1 ? true : false);

                    lista.Add(turno);
                }
                return lista;

            }
            catch (Exception)
            {

                throw new ErrorLecturaException("No se ha encontrado la base de datos. Revise si ejecutó el script y reinicie");
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
                string query = "DELETE FROM Turnos WHERE id_Turno = @idBuscado";

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

        public void EliminarPorIdPaciente(int idPaciente)
        {
            try
            {
                string query = "DELETE FROM Turnos WHERE id_Paciente = @idBuscado";

                connection.Open();

                command.CommandText = query;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("idBuscado", idPaciente);

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
