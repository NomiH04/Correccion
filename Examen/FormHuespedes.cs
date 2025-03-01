using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DALL;

namespace Examen
{
    public partial class FormHuespedes : Form
    {
        ConexionHuesped _conexion;
        string correoHuespued = "";
        public FormHuespedes()
        {
            InitializeComponent();
            _conexion = new ConexionHuesped(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
            //CargarDataHuesped();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del huésped.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet datos = _conexion.Leer(txtBuscar.Text);

                if (datos.Tables.Count == 0 || datos.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Huésped no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataHuesped.DataSource = datos.Tables[0];
                dataHuesped.AutoResizeColumns();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error en la base de datos: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener la referencia del formulario padre (MainForm)
            FormPrincipal main = this.ParentForm as FormPrincipal;

            if (main != null)
            {
                // Llamar al método para abrir otro formulario dentro del MainForm
                main.AbrirFormulario(new FormAgregarEditarHuespedes());
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
                    correoHuespued = filaSeleccionada.Cells["correoHuesped"].Value.ToString();
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataHuesped.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataHuesped.SelectedRows[0];

                Huespedes huespedSeleccionado = new Huespedes
                {
                    idHuesped = Convert.ToInt32(row.Cells["idHuespedes"].Value),
                    nombreCompleto = row.Cells["nombreCompleto"].Value.ToString(),
                    fechaNacimiento = Convert.ToDateTime(row.Cells["fechaNacimiento"].Value),
                    genero = row.Cells["genero"].Value.ToString(),
                    telefono = row.Cells["telefono"].Value.ToString(),
                    correoElectronico = row.Cells["correoElectronico"].Value.ToString(),
                    direccion = row.Cells["direccion"].Value.ToString(),
                    fotoHuesped = row.Cells["fotoHuesped"].Value?.ToString() // Evita nulos
                };

                // Obtener la referencia del formulario padre (MainForm)
                FormPrincipal main = this.ParentForm as FormPrincipal;

                if (main != null)
                {
                    // Llamar al método para abrir otro formulario dentro del MainForm
                    main.AbrirFormulario(new FormAgregarEditarHuespedes(huespedSeleccionado));
                }
            }
            else
            {
                MessageBox.Show("Seleccione un huésped de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataHuesped.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataHuesped.SelectedRows[0];

                // Obtener el correo electrónico del huésped seleccionado
                string correo = dataHuesped.SelectedRows[0].Cells["correoElectronico"].Value.ToString();

                // Confirmación antes de eliminar
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este huésped?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _conexion.Borrar(correo); // Llamada al método para eliminar el huésped

                        MessageBox.Show("Huésped eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Opcional: Actualizar la tabla después de la eliminación
                        CargarDataHuesped();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el huésped: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un huésped de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
 