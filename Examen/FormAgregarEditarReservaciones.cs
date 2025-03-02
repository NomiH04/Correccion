using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DALL;

namespace Examen
{
    public partial class FormAgregarEditarReservaciones : Form
    {
        ConexionReserva _conexion;
        public FormAgregarEditarReservaciones()
        {
            InitializeComponent();
            _conexion = new ConexionReserva(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Recuperamos los datos de los campos de texto
                int idHuesped = int.Parse(txtIDHuesped.Text);
                int idHabitacion = int.Parse(txtIDHabitacion.Text);
                string fechaCheckIn = txtCheckIN.Text;
                string fechaCheckOut = txtCheckOUT.Text;
                string estado = cbEstado.SelectedItem.ToString();
                decimal montoTotal = decimal.Parse(txtMonto.Text);
                string observaciones = txtObservaciones.Text;

                // Creamos el objeto Huespedes con los datos recibidos
                Reservaciones huesped = new Reservaciones(idHuesped, idHabitacion, DateTime.Parse(fechaCheckIn), DateTime.Parse(fechaCheckOut),
                    estado, montoTotal, observaciones);

                // Guardamos el huesped utilizando el método GuardarHuesped
                _conexion.GuardarReserva(huesped);

                MessageBox.Show("Huésped guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error en el formato de los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
