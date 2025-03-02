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
    public class ConexionHuesped
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string strConnection;

        public ConexionHuesped(string connection)
        {
            strConnection = connection;
        }
        public void GuardarHuesped(Huespedes huesped)
        {
            try
            {
                _connection = new SqlConnection(strConnection);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Ins_Huesped]";
                _command.Parameters.AddWithValue("@NombreCompleto", huesped.nombreCompleto);
                _command.Parameters.AddWithValue("@fechaNacimiento", huesped.fechaNacimiento);
                _command.Parameters.AddWithValue("@genero", huesped.genero);
                _command.Parameters.AddWithValue("@telefono", huesped.telefono);
                _command.Parameters.AddWithValue("@correoElectronico", huesped.correoElectronico);
                _command.Parameters.AddWithValue("@direccion", huesped.direccion);
                _command.Parameters.AddWithValue("@fotoHuesped", huesped.fotoHuesped);
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

        public DataSet LeerTodosLosHuespedes()
        {
            DataSet datos = new DataSet();
            string query = "SELECT * FROM Huespedes"; // Consulta para obtener todos los registros

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


        public void Modificar(Huespedes huesped)
        {
            try
            {
                _connection = new SqlConnection(strConnection);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[Upd_Huesped]";
                _command.Parameters.AddWithValue("@idHuespedes", huesped.idHuesped);
                _command.Parameters.AddWithValue("@NombreCompleto", huesped.nombreCompleto);
                _command.Parameters.AddWithValue("@fechaNacimiento", huesped.fechaNacimiento);
                _command.Parameters.AddWithValue("@genero", huesped.genero);
                _command.Parameters.AddWithValue("@telefono", huesped.telefono);
                _command.Parameters.AddWithValue("@correoElectronico", huesped.correoElectronico);
                _command.Parameters.AddWithValue("@direccion", huesped.direccion);
                _command.Parameters.AddWithValue("@fotoHuesped", huesped.fotoHuesped);
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

        public DataSet Leer(string name)
        {
            DataSet datos = new DataSet();
            try
            {
                using (SqlConnection _connection = new SqlConnection(strConnection))
                {
                    _connection.Open();
                    using (SqlCommand _command = new SqlCommand("[read_Huesped]", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@NombreCompleto", name);

                        using (SqlDataAdapter _adapter = new SqlDataAdapter(_command))
                        {
                            _adapter.Fill(datos); // Llenar el DataSet con los resultados
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer datos: " + ex.Message);
            }
            return datos;
        }

        public bool LeerCorreo(string correo)
        {
            bool correoExistente = false; // Inicializamos la variable a false, asumiendo que el correo no existe
            try
            {
                using (SqlConnection _connection = new SqlConnection(strConnection))
                {
                    _connection.Open();
                    using (SqlCommand _command = new SqlCommand("[read_Huespedes]", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@correoElectronico", correo);

                        using (SqlDataAdapter _adapter = new SqlDataAdapter(_command))
                        {
                            DataSet datos = new DataSet();
                            _adapter.Fill(datos); // Llenar el DataSet con los resultados

                            // Si el DataSet contiene al menos una tabla con datos, el correo existe
                            if (datos.Tables.Count > 0 && datos.Tables[0].Rows.Count > 0)
                            {
                                correoExistente = true; // El correo ya existe
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer datos: " + ex.Message);
            }
            return correoExistente;
        }

        public void Borrar(string correo)
        {
            try
            {
                _connection = new SqlConnection(strConnection);
                _connection.Open();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[del_Huesped]";
                _command.Parameters.AddWithValue("@correoElectronico", correo);
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
