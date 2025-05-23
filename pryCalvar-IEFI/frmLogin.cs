using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCalvar_IEFI
{
    public partial class Form1 : Form
    {

        clsConexion conexion = new clsConexion();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text != "" || txtContrasena.Text != "")
            {
                string nombre = txtUsuario.Text;
                string clave = txtContrasena.Text;

                int? usuarioID = conexion.IniciarSesion(nombre, clave);

                if (usuarioID != null)
                {
                    frmPrincipal principal = new frmPrincipal(usuarioID.Value);
                    this.Hide();
                    principal.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            else
            {
                MessageBox.Show("Porfavor ingresa la clave o el usuario.");
            }
        }
    }
}
