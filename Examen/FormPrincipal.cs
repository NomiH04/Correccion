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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        public void AbrirFormulario(Form childForm)
        {
            // Limpiar el panel antes de abrir otro formulario
            panelContenedor.Controls.Clear();

            // Configurar formulario como hijo del panel
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnHuespedes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormHuespedes());
        }

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormHabitaciones());
        }

        private void btnReservaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReservaciones());
        }

        private void salirbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
