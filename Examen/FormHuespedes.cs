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
    public partial class FormHuespedes : Form
    {
        ConexionHuesped _conexion;
        public FormHuespedes()
        {
            InitializeComponent();
            _conexion = new ConexionHuesped(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
            //CargarDataHuesped();
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
                main.AbrirFormulario (new FormAgregarEditarHuespedes());
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            // Obtener la referencia del formulario padre (MainForm)
            FormPrincipal main = this.ParentForm as FormPrincipal;

            if (main != null)
            {
                // Llamar al método para abrir otro formulario dentro del MainForm
                main.AbrirFormulario(new FormReporteHuespedes());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataHuesped_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verifica que el índice de la fila sea válido (evita clics en la cabecera)
                if (e.RowIndex >= 0)
                {
                    // Obtiene la fila seleccionada
                    DataGridViewRow filaSeleccionada = dataHuesped.Rows[e.RowIndex];

                    // Marca la fila como seleccionada (esto selecciona toda la fila)
                    filaSeleccionada.Selected = true;

                    // Obtiene el ID del huésped (suponiendo que la primera columna es el ID)
                    int idHuesped = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);

                    // Muestra el ID en un TextBox (opcional)
                    txtBuscar.Text = idHuesped.ToString();
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
            dataHuesped.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // No permitir la selección múltiple, solo una fila a la vez
            dataHuesped.MultiSelect = false;
        }

        public void CargarDataHuesped ()
        {
            // Llamar al método que obtiene todos los registros de la tabla Huespedes
            DataSet datos = _conexion.LeerTodosLosHuespedes();

            // Verificar si el DataSet contiene datos
            if (datos.Tables.Count > 0)
            {
                // Asignar el DataTable (primera tabla) al DataGridView
                dataHuesped.DataSource = datos.Tables[0];
            }
            else
            {
                MessageBox.Show("No se encontraron registros.");
            }
        }

        private void FormHuespedes_Load(object sender, EventArgs e)
        {
            CargarDataHuesped();
            ConfigurarDataGridView();
        }
    }
}
 