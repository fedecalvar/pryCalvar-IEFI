using pryCalvar_IEFI.Datos;
using pryCalvar_IEFI.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCalvar_IEFI.Formularios
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();

            pbRegistro.Image = Properties.Resources.nuevo_usuario;

            txtContrasena.MaxLength = 20;
            txtRepetirContrasena.MaxLength = 20;
            txtNombreCompleto.MaxLength = 100;
            txtEmail.MaxLength = 100;
            txtNombreUsuario.MaxLength = 30;
            txtTelefono.MaxLength = 15;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                    string.IsNullOrWhiteSpace(txtRepetirContrasena.Text) ||
                    string.IsNullOrWhiteSpace(txtNombreCompleto.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Por favor, completá todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtContrasena.Text != txtRepetirContrasena.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nombre = txtNombreUsuario.Text.Trim();
                string correo = txtEmail.Text.Trim();

                if (UsuarioDatos.ExisteNombreUsuario(nombre))
                {
                    MessageBox.Show("El nombre de usuario ya está en uso. Elegí otro.", "Nombre duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (UsuarioDatos.ExisteEmail(correo))
                {
                    MessageBox.Show("El correo electrónico ya está registrado. Usá uno diferente.", "Email duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Usuario nuevoUsuario = new Usuario
                {
                    NombreUsuario = txtNombreUsuario.Text.Trim(),
                    Contrasena = txtContrasena.Text.Trim(),
                    NombreCompleto = txtNombreCompleto.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim()
                };

                Usuario registrado = UsuarioDatos.RegistrarUsuario(nuevoUsuario);

                if (registrado != null)
                {
                    MessageBox.Show("Usuario registrado exitosamente.", "Registro completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el usuario. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se permite escribir letras ni simbolos, solo números
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla
            }
        }

    }
}
