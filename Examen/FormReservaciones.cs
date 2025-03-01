using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class FormReservaciones : Form
    {
        public FormReservaciones()
        {
            InitializeComponent();
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
                main.AbrirFormulario(new FormAgregarEditarReservaciones());
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            // Obtener la referencia del formulario padre (MainForm)
            FormPrincipal main = this.ParentForm as FormPrincipal;

            if (main != null)
            {
                // Llamar al método para abrir otro formulario dentro del MainForm
                main.AbrirFormulario(new FormReporteReservacion());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
