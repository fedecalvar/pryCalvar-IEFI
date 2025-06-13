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
    public partial class frmAgregar : Form
    {
        private int idUsuario;
        public frmAgregar(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;

            txtTitulo.MaxLength = 50;
            txtDescripcion.MaxLength = 250;

            cboPrioridad.Items.AddRange(new string[] { "Alta", "Media", "Baja" });
            cboPrioridad.SelectedIndex = 1;


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text) || cboPrioridad.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor completá todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Tarea nuevaTarea = new Tarea

                {
                    Titulo = txtTitulo.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    FechaVencimiento = dtpFechaVencimiento.Value,
                    Prioridad = cboPrioridad.SelectedItem.ToString(),
                    Estado = "Pendiente", // <-- Estado pendiente por defecto
                    IdUsuario = idUsuario
                };

                // Guardar en la base de datos
                TareaDatos.AgregarTarea(nuevaTarea);

                MessageBox.Show("Tarea agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la tarea:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
