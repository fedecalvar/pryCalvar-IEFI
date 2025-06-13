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
    public partial class frmModificarEliminar : Form
    {

        private Tarea tarea;

        public frmModificarEliminar(Tarea tarea)
        {
            InitializeComponent();

            this.tarea = tarea;

            // Cargar datos
            txtTitulo.Text = tarea.Titulo;
            txtDescripcion.Text = tarea.Descripcion;
            dtpFechaVencimiento.Value = tarea.FechaVencimiento;

            cboPrioridad.Items.AddRange(new string[] { "Baja", "Media", "Alta" });
            cboPrioridad.SelectedItem = tarea.Prioridad;

            cboEstado.Items.AddRange(new string[] { "Pendiente", "En progreso", "Finalizada" });
            cboEstado.SelectedItem = tarea.Estado;

            txtTitulo.MaxLength = 50;
            txtDescripcion.MaxLength = 250;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text) || cboPrioridad.SelectedIndex == -1 || cboEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Completá todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tarea.Titulo = txtTitulo.Text.Trim();
                tarea.Descripcion = txtDescripcion.Text.Trim();
                tarea.FechaVencimiento = dtpFechaVencimiento.Value;
                tarea.Prioridad = cboPrioridad.SelectedItem.ToString();
                tarea.Estado = cboEstado.SelectedItem.ToString();

                TareaDatos.ModificarTarea(tarea);

                MessageBox.Show("Tarea modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la tarea:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Estás seguro de que querés eliminar esta tarea?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    TareaDatos.EliminarTarea(tarea.IdTarea);
                    MessageBox.Show("Tarea eliminada correctamente.", "Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la tarea:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
