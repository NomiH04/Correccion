using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class ConexionReserva
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string strConnection;

        public ConexionReserva(string connection)
        {
            strConnection = connection;
        }

        public void GuardarReserva(Reservaciones reservas)
        {
            try
            {
                _connection = new SqlConnection(strConnection);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Ins_Reserva]";
                _command.Parameters.AddWithValue("@idHuesped", reservas.idReserva);
                _command.Parameters.AddWithValue("@idHabitacion", reservas.idReserva);
                _command.Parameters.AddWithValue("@fechaCheckIn", reservas.fechaCheckIn);
                _command.Parameters.AddWithValue("@fechaCheckOut", reservas.fechaCheckOut);
                _command.Parameters.AddWithValue("@estadoReserva", reservas.estadoReserva);
                _command.Parameters.AddWithValue("@montoTotal", reservas.montoTotal);
                _command.Parameters.AddWithValue("@observaciones", reservas.Observaciones);
                _command.ExecuteNonQuery();
                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet LeerTodasLasReservaciones()
        {
            DataSet datos = new DataSet();
            string query = "SELECT * FROM Reservas"; // Consulta para obtener todos los registros

            try
            {
                using (SqlConnection _connection = new SqlConnection(strConnection))
                {
                    _connection.Open();
                    using (SqlCommand _command = new SqlCommand(query, _connection)) // Usamos la consulta directa
                    {
                        SqlDataAdapter _adapter = new SqlDataAdapter(_command);
                        _adapter.Fill(datos); // Llenar el DataSet con los resultados de la consulta
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer los datos: " + ex.Message);
            }

            return datos;
        }
        public void Modificar(Reservaciones reservas)
        {
            try
            {
                _connection = new SqlConnection(strConnection);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Upd_Reserva]";
                _command.Parameters.AddWithValue("@idReserva", reservas.idReserva);
                _command.Parameters.AddWithValue("@fechaCheckIn", reservas.fechaCheckIn);
                _command.Parameters.AddWithValue("@fechaCheckOut", reservas.fechaCheckOut);
                _command.Parameters.AddWithValue("@estadoReserva", reservas.estadoReserva);
                _command.Parameters.AddWithValue("@montoTotal", reservas.montoTotal);
                _command.Parameters.AddWithValue("@observaciones", reservas.Observaciones); ;
                _command.ExecuteNonQuery();
                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Leer(string id)
        {
            try
            {
                _connection = new SqlConnection(strConnection);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[read_Reserva]";
                _command.Parameters.AddWithValue("@idReserva", id);
                SqlDataAdapter _adapter = new SqlDataAdapter();
                DataSet datos = new DataSet();
                _adapter.SelectCommand = _command;
                _adapter.Fill(datos);
                _adapter.Dispose();
                _command.ExecuteNonQuery();
                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Borrar(string id)
        {
            try
            {
                _connection = new SqlConnection(strConnection);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[del_Reserva]";
                _command.Parameters.AddWithValue("@idReserva", id);
                _command.ExecuteNonQuery();
                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
