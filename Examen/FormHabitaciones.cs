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
using DALL;

namespace Examen
{
    public partial class FormHabitaciones : Form
    {
        ConexionHabitacion _conexion;
        public FormHabitaciones()
        {
            InitializeComponent();
            _conexion = new ConexionHabitacion(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener la referencia del formulario padre (MainForm)
            FormPrincipal main = this.ParentForm as FormPrincipal;

            if (main != null)
            {
                // Llamar al método para abrir otro formulario dentro del MainForm
                main.AbrirFormulario(new FormAgregarEditarHabitacion());
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            // Obtener la referencia del formulario padre (MainForm)
            FormPrincipal main = this.ParentForm as FormPrincipal;

            if (main != null)
            {
                // Llamar al método para abrir otro formulario dentro del MainForm
                main.AbrirFormulario(new FormReporteHabitaciones());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataHabitacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verifica que el índice de la fila sea válido (evita clics en la cabecera)
                if (e.RowIndex >= 0)
                {
                    // Obtiene la fila seleccionada
                    DataGridViewRow filaSeleccionada = dataHabitacion.Rows[e.RowIndex];

                    // Marca la fila como seleccionada (esto selecciona toda la fila)
                    filaSeleccionada.Selected = true;

                    // Obtiene el ID del huésped (suponiendo que la primera columna es el ID)
                    int idHabitacion = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);

                    // Muestra el ID en un TextBox (opcional)
                    txtBuscar.Text = idHabitacion.ToString();
                }
            }
            catch (FormatException ex)
            {
                // Captura errores de conversión (por ejemplo, si "ID" no es un número válido)
                MessageBox.Show("Error de formato al intentar convertir el ID del huésped. Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Captura errores si el índice de la fila está fuera del rango (por ejemplo, si no hay filas)
                MessageBox.Show("Error: El índice de la fila es inválido. Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Captura cualquier otro tipo de excepción
                MessageBox.Show("Ha ocurrido un error inesperado. Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Asegúrate de que se pueda seleccionar toda la fila, no solo las celdas individuales
            dataHabitacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // No permitir la selección múltiple, solo una fila a la vez
            dataHabitacion.MultiSelect = false;
        }

        public void CargarDataHabitacion()
        {
            // Llamar al método que obtiene todos los registros de la tabla Huespedes
            DataSet datos = _conexion.LeerTodasLasHabitaciones();

            // Verificar si el DataSet contiene datos
            if (datos.Tables.Count > 0)
            {
                // Asignar el DataTable (primera tabla) al DataGridView
                dataHabitacion.DataSource = datos.Tables[0];
            }
            else
            {
                MessageBox.Show("No se encontraron registros.");
            }
        }

        private void FormHabitaciones_Load(object sender, EventArgs e)
        {
            CargarDataHabitacion();
            ConfigurarDataGridView();
        }
    }
}
