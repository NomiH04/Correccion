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
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Examen
{
    public partial class FormAgregarEditarHuespedes : Form
    {
        ConexionHuesped _conexion;

        public FormAgregarEditarHuespedes()
        {
            InitializeComponent();
            _conexion = new ConexionHuesped(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
            btnModificar.Enabled = false;
        }

        public FormAgregarEditarHuespedes (Huespedes huespedSeleccionado)
        {
            InitializeComponent();
            _conexion = new ConexionHuesped(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);

            if (huespedSeleccionado != null)
            {
                txtID.Text = huespedSeleccionado.idHuesped.ToString();
                txtNombre.Text = huespedSeleccionado.nombreCompleto;
                txtFecha.Text = huespedSeleccionado.fechaNacimiento.ToString("dd-MM-yyyy");
                txtGenero.Text = huespedSeleccionado.genero;
                txtTelefono.Text = huespedSeleccionado.telefono;
                txtCorreo.Text = huespedSeleccionado.correoElectronico;
                txtDireccion.Text = huespedSeleccionado.direccion;
                CargarImagen(huespedSeleccionado.fotoHuesped);
            }
            btnAgregar.Enabled = false;
            txtNombre.Enabled = false;
            txtFecha.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validar que los campos obligatorios no estén vacíos
            if (
                string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtTelefono.Text) ||
                string.IsNullOrEmpty(txtCorreo.Text) ||
                string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay campos vacíos
            }

            // Validar nombre: Debe ser texto con letras (sin números)
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El nombre solo debe contener letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar fecha de nacimiento (dd/MM/yyyy)
            DateTime fechaNacimiento;
            if (!DateTime.TryParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
            {
                MessageBox.Show("La fecha debe tener el formato dd/MM/yyyy.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar teléfono (Formato: código de país + número único)
            string telefono = txtTelefono.Text;
            if (!Regex.IsMatch(telefono, @"^\+\d{1,4}\s?\d{6,14}$"))
            {
                MessageBox.Show("El teléfono debe tener el formato código de país + número único.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar correo electrónico (debe tener un formato válido)
            string correo = txtCorreo.Text;
            if (!Regex.IsMatch(correo, @"^[^@]+@[^@]+\.[^@]+$"))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el correo ya está registrado (esto requiere consultar tu base de datos)
            bool existe = _conexion.LeerCorreo("correo@ejemplo.com");
            if (existe)
            {
                MessageBox.Show("Este correo electrónico ya está registrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                // Recuperamos los datos de los campos de texto
                string nombre = txtNombre.Text;
                string fecha = txtFecha.Text;
                string genero = txtGenero.Text;
                telefono = txtTelefono.Text;
                correo = txtCorreo.Text;
                string direccion = txtDireccion.Text;
                string foto = GuardarImagen();

                // Creamos el objeto Huespedes con los datos recibidos
                Huespedes huesped = new Huespedes(nombre, DateTime.Parse(fecha), genero, telefono, correo, direccion, foto);

                // Guardamos el huesped utilizando el método GuardarHuesped
                _conexion.GuardarHuesped(huesped);

                MessageBox.Show("Huésped guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
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

        private Image RedimensionarImagen(Image img, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return resizedImage;
        }


        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image originalImage = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image = RedimensionarImagen(originalImage, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Ajuste de imagen
                pictureBox1.Tag = openFileDialog.FileName; // Guardar la ruta temporalmente en el Tag
            }
        }

        private string GuardarImagen()
        {
            string rutaDestino = "";

            try
            {
                // Definir la carpeta de destino dentro del proyecto
                string carpetaDestino = Path.Combine(Application.StartupPath, "ImagenesHuespedes");

                // Crear la carpeta si no existe
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                // Verificar si hay una imagen cargada
                if (pictureBox1.Image != null && pictureBox1.Tag != null)
                {
                    // Obtener la extensión del archivo original
                    string extension = Path.GetExtension(pictureBox1.Tag.ToString());

                    // Generar un nombre único para la imagen
                    string nombreArchivo = Guid.NewGuid().ToString() + extension;
                    rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);

                    // Redimensionar la imagen antes de guardarla
                    Image imagenRedimensionada = RedimensionarImagen(pictureBox1.Image, 300, 300);

                    // Guardar la imagen redimensionada en la carpeta
                    imagenRedimensionada.Save(rutaDestino, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rutaDestino;
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Validar que los campos obligatorios no estén vacíos
            if (
                string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtTelefono.Text) ||
                string.IsNullOrEmpty(txtCorreo.Text) ||
                string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay campos vacíos
            }

            // Validar nombre: Debe ser texto con letras (sin números)
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El nombre solo debe contener letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar fecha de nacimiento (dd/MM/yyyy)
            DateTime fechaNacimiento;
            if (!DateTime.TryParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
            {
                MessageBox.Show("La fecha debe tener el formato dd/MM/yyyy.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar teléfono (Formato: código de país + número único)
            string telefono = txtTelefono.Text;
            if (!Regex.IsMatch(telefono, @"^\+\d{1,4}\s?\d{6,14}$"))
            {
                MessageBox.Show("El teléfono debe tener el formato código de país + número único.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar correo electrónico (debe tener un formato válido)
            string correo = txtCorreo.Text;
            if (!Regex.IsMatch(correo, @"^[^@]+@[^@]+\.[^@]+$"))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el correo ya está registrado (esto requiere consultar tu base de datos)
            bool existe = _conexion.LeerCorreo("correo@ejemplo.com");
            if (existe)
            {
                MessageBox.Show("Este correo electrónico ya está registrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                // Recuperamos los datos de los campos de texto
                int id = int.Parse(txtID.Text);
                string nombre = txtNombre.Text;
                string fecha = txtFecha.Text;
                string genero = txtGenero.Text;
                telefono = txtTelefono.Text;
                correo = txtCorreo.Text;
                string direccion = txtDireccion.Text;
                string foto = pictureBox1.Tag?.ToString(); // Ruta de la imagen actual

                if (pictureBox1.Image != null && pictureBox1.Tag != null && !File.Exists(foto))
                {
                    foto = GuardarImagen();
                }

                Huespedes huespedSeleccionado = new Huespedes(id, nombre, DateTime.Parse(fecha), genero, telefono,
                    correo, direccion, foto);

                if (_conexion == null)
                {
                    MessageBox.Show("Error: La conexión no ha sido inicializada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Llamamos al método para guardar los cambios en la base de datos
                _conexion.Modificar(huespedSeleccionado);  // El método ModificarHuesped debe ser implementado para actualizar los datos

                MessageBox.Show("Huésped modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
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

        private void CargarImagen(string rutaImagen)
        {
            if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
            {
                Image img = Image.FromFile(rutaImagen);
                pictureBox1.Image = RedimensionarImagen(img, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Tag = rutaImagen; // Guardar la ruta en el Tag para referencia
            }
            else
            {
                pictureBox1.Image = null; // Si no hay imagen, limpiar el PictureBox
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

        public void Limpiar ()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtFecha.Text = "";
            txtGenero.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            pictureBox1.Image = null;
        }
    }
}
