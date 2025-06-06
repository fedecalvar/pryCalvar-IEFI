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
using FontAwesome.Sharp;
using pryCalvar_IEFI.Formularios;

namespace pryCalvar_IEFI
{
    public partial class frmLogin : Form
    {

        clsConexion conexion = new clsConexion();

        public frmLogin()
        {
            InitializeComponent();

            //pbIconoInicioSesion.Image = Properties.Resources.icono_inicio_sesion;
            txtUsuario.MaxLength = 30;
            txtContrasena.MaxLength = 20;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUsuario.Text != "" && txtContrasena.Text != "")
                {
                    string nombreUsuario = txtUsuario.Text;
                    string contrasena = txtContrasena.Text;

                    Usuario usuarioLogueado = UsuarioDatos.IniciarSesion(nombreUsuario, contrasena);

                    if (usuarioLogueado != null)
                    {
                        frmPrincipal principal = new frmPrincipal(usuarioLogueado);
                        this.Hide();
                        principal.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingresá el usuario y la contraseña", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            frmRegistro registro = new frmRegistro();
            registro.Show();
        }
    }
}
