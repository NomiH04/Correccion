using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using BLL;
using DALL;

namespace Examen
{
    public partial class FormAgregarEditarHuespedes : Form
    {
        ConexionHuesped _conexion;

        public FormAgregarEditarHuespedes()
        {
            InitializeComponent();
            _conexion = new ConexionHuesped(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Recuperamos los datos de los campos de texto
                string nombre = txtNombre.Text;
                string fecha = txtFecha.Text;
                string genero = txtGenero.Text;
                string telefono = txtTelefono.Text;
                string correo = txtCorreo.Text;
                string direccion = txtDireccion.Text;
                string foto = pictureBox1.ProductName;

                // Creamos el objeto Huespedes con los datos recibidos
                Huespedes huesped = new Huespedes(nombre, DateTime.Parse(fecha), genero, telefono, correo, direccion, foto);

                // Guardamos el huesped utilizando el método GuardarHuesped
                _conexion.GuardarHuesped(huesped);

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
                main.AbrirFormulario(new FormHuespedes());
            }
        }
    }
}
