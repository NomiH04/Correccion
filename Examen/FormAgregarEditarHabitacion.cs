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
    public partial class FormAgregarEditarHabitacion : Form
    {
        ConexionHabitacion _conexion;
        public FormAgregarEditarHabitacion()
        {
            InitializeComponent();
            _conexion = new ConexionHabitacion(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Recuperamos los datos de los campos de texto
                int numeroHabitacion = int.Parse(txtNumero.Text);
                string tipoHabitacion = cbTipoHabitacion.SelectedItem.ToString();
                decimal precio = decimal.Parse(txtPrecio.Text);
                int capacidad = int.Parse(txtCapacidad.Text);
                int estancia = int.Parse(txtDuracion.Text);
                string estado = cbEstado.SelectedItem.ToString();
                string servicios = txtServicios.Text;
                string foto = pictureBox1.ProductName;

                // Creamos el objeto Huespedes con los datos recibidos
                Habitaciones habitacion = new Habitaciones (numeroHabitacion, tipoHabitacion, precio, capacidad, estancia, estado, servicios,foto);

                // Guardamos el huesped utilizando el método GuardarHuesped
                _conexion.GuardarHabitacion(habitacion);

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Obtener la referencia del formulario padre (MainForm)
            FormPrincipal main = this.ParentForm as FormPrincipal;

            if (main != null)
            {
                // Llamar al método para abrir otro formulario dentro del MainForm
                main.AbrirFormulario(new FormHabitaciones());
            }
        }
    }
}
