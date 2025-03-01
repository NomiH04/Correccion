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
    public class ConexionHabitacion
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string strConnection;

        public ConexionHabitacion(string connection)
        {
            strConnection = connection;
        }
        public void GuardarHabitacion(Habitaciones habitacion)
        {
            try
            {
                _connection = new SqlConnection(strConnection);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Ins_Habitacion]";
                _command.Parameters.AddWithValue("@habitacion", habitacion.habitacion);
                _command.Parameters.AddWithValue("@tipoHabitacion", habitacion.tipoHabitacion);
                _command.Parameters.AddWithValue("@precio", habitacion.precio);
                _command.Parameters.AddWithValue("@capacidadMax", habitacion.capacidadMaxima);
                _command.Parameters.AddWithValue("@duracionEstancia", habitacion.duracionEstancia);
                _command.Parameters.AddWithValue("@estado", habitacion.estado);
                _command.Parameters.AddWithValue("@servicios", habitacion.servicios);
                _command.Parameters.AddWithValue("@imagenHabitacion", habitacion.imagenHabitacion);
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

        public DataSet LeerTodasLasHabitaciones()
        {
            DataSet datos = new DataSet();
            string query = "SELECT * FROM Habitaciones"; // Consulta para obtener todos los registros

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

        public void Modificar(Habitaciones habitacion)
        {
            try
            {
                _connection = new SqlConnection(strConnection);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Upd_Habitacion]";
                _command.Parameters.AddWithValue("@idHabitacion", habitacion.idHabitacion);
                _command.Parameters.AddWithValue("@habitacion", habitacion.habitacion);
                _command.Parameters.AddWithValue("@tipoHabitacion", habitacion.tipoHabitacion);
                _command.Parameters.AddWithValue("@precio", habitacion.precio);
                _command.Parameters.AddWithValue("@capacidadMax", habitacion.capacidadMaxima);
                _command.Parameters.AddWithValue("@duracionEstancia", habitacion.duracionEstancia);
                _command.Parameters.AddWithValue("@estado", habitacion.estado);
                _command.Parameters.AddWithValue("@servicios", habitacion.servicios);
                _command.Parameters.AddWithValue("@imagenHabitacion", habitacion.imagenHabitacion);
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
        public DataSet Leer(string numero)
        {
            try
            {
                _connection = new SqlConnection(strConnection);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[read_Habitacion]";
                _command.Parameters.AddWithValue("@Habitacion", numero);
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
        public void Borrar(string numero)
        {
            try
            {
                _connection = new SqlConnection(strConnection);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[del_Habitacion]";
                _command.Parameters.AddWithValue("@habitacion", numero);
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
