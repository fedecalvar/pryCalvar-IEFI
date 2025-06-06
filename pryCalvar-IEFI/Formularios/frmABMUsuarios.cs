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
    public partial class frmABMUsuarios : Form
    {
        public frmABMUsuarios()
        {
            InitializeComponent();

            CargarUsuariosCombo();

            cboTipoUsuario.Items.Clear();
            cboTipoUsuario.Items.Add("Administrador");
            cboTipoUsuario.Items.Add("Usuario");

            cboTipoUsuarioRegistro.Items.Clear();
            cboTipoUsuarioRegistro.Items.Add("Administrador");
            cboTipoUsuarioRegistro.Items.Add("Usuario");
        }

        private void CargarUsuariosCombo()
        {
            cboUsuarios.DataSource = null;
            cboUsuarios.DataSource = UsuarioDatos.ObtenerTodos();
            cboUsuarios.DisplayMember = "NombreUsuario";
            cboUsuarios.ValueMember = "Id";
            cboUsuarios.SelectedIndex = -1;

            cboEliminarUsuario.DataSource = null;
            cboEliminarUsuario.DataSource = UsuarioDatos.ObtenerTodos();
            cboEliminarUsuario.DisplayMember = "NombreUsuario";
            cboEliminarUsuario.ValueMember = "Id";
            cboEliminarUsuario.SelectedIndex = -1;
        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUsuarios.SelectedItem != null)
            {
                Usuario usuario = (Usuario)cboUsuarios.SelectedItem;

                txtNombreCompletoModificar.Text = usuario.NombreCompleto;
                txtEmailModificar.Text = usuario.Email;
                txtTelefonoModificar.Text = usuario.Telefono;
                cboTipoUsuario.SelectedItem = usuario.TipoUsuario;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cboUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un usuario primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario original = (Usuario)cboUsuarios.SelectedItem;

            Usuario actualizado = new Usuario
            {
                Id = original.Id,
                NombreUsuario = original.NombreUsuario,
                Contrasena = original.Contrasena,
                TipoUsuario = cboTipoUsuario.SelectedItem?.ToString(),
                NombreCompleto = txtNombreCompletoModificar.Text.Trim(),
                Email = txtEmailModificar.Text.Trim(),
                Telefono = txtTelefonoModificar.Text.Trim()
            };

            bool exito = UsuarioDatos.ModificarUsuario(actualizado);

            if (exito)
            {
                MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuariosCombo();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(cboEliminarUsuario.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario seleccionado = (Usuario)cboEliminarUsuario.SelectedItem;

            DialogResult confirmacion = MessageBox.Show(
            $"¿Seguro que querés eliminar a {seleccionado.NombreUsuario}?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                bool eliminado = UsuarioDatos.EliminarUsuario(seleccionado.Id);

                if (eliminado)
                {
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //CargarUsuariosCombo();
                    CargarUsuariosCombo(); // También actualizás el Combo de Modificar
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreUsuarioRegistro.Text) ||
                    string.IsNullOrWhiteSpace(txtContrasenaRegistro.Text) ||
                    string.IsNullOrWhiteSpace(txtRepetirContrasenaRegistro.Text) ||
                    string.IsNullOrWhiteSpace(txtNombreCompletoRegistro.Text) ||
                    string.IsNullOrWhiteSpace(txtEmailRegistro.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefonoRegistro.Text) ||
                    cboTipoUsuarioRegistro.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, completá todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtContrasenaRegistro.Text != txtRepetirContrasenaRegistro.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nombre = txtNombreUsuarioRegistro.Text.Trim();
                string correo = txtEmailRegistro.Text.Trim();

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
                    NombreUsuario = txtNombreUsuarioRegistro.Text.Trim(),
                    Contrasena = txtContrasenaRegistro.Text.Trim(),
                    NombreCompleto = txtNombreCompletoRegistro.Text.Trim(),
                    Email = txtEmailRegistro.Text.Trim(),
                    Telefono = txtTelefonoRegistro.Text.Trim(),
                    TipoUsuario = cboTipoUsuarioRegistro.SelectedItem.ToString()
                };

                Usuario registrado = UsuarioDatos.RegistrarUsuario(nuevoUsuario);

                if (registrado != null)
                {
                    MessageBox.Show("Usuario registrado exitosamente.", "Registro completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuariosCombo();
                    LimpiarCamposAlta();
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
        private void LimpiarCampos()
        {
            cboUsuarios.SelectedIndex = -1;
            txtNombreCompletoModificar.Clear();
            txtEmailModificar.Clear();
            txtTelefonoModificar.Clear();
            cboTipoUsuario.SelectedIndex = -1;
        }
        private void LimpiarCamposAlta()
        {
            txtNombreUsuarioRegistro.Clear();
            txtNombreUsuarioRegistro.Clear();
            txtContrasenaRegistro.Clear();
            txtRepetirContrasenaRegistro.Clear();
            txtTelefonoRegistro.Clear();
            txtEmailRegistro.Clear();
            cboTipoUsuarioRegistro.SelectedIndex = -1;
        }

    }
}

