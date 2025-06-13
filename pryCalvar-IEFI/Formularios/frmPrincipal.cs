using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using pryCalvar_IEFI.Modelos;
using pryCalvar_IEFI.Datos;
using pryCalvar_IEFI.Formularios;


namespace pryCalvar_IEFI
{
    public partial class frmPrincipal : Form
    {
        // declaramos un campo privado dentro del formulario frmPrincipal
        // llamamos a usuarioActual que guarda el objeto "Usuario" que viene desde el login
        private Usuario usuarioActual;
        private Stopwatch cronometro;
        private DateTime inicio;

        public frmPrincipal(Usuario usuario)
        {
            InitializeComponent();

            // cuando se cierre el frmPrincipal
            // se ejecuta frmPrincipal_FormClosing
            this.FormClosing += frmPrincipal_FormClosing;

            usuarioActual = usuario;

            cronometro = new Stopwatch();
            cronometro.Start();

            inicio = DateTime.Now;

            mostrarInfoUsuario();
            CargarComboTipoUsuario();
            cargarTareasUsuario();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar agregarTarea = new frmAgregar(usuarioActual.Id);
            agregarTarea.Show();
        }

        private void btnABMUsuarios_Click(object sender, EventArgs e)
        {
            frmABMUsuarios ABMUsuarios = new frmABMUsuarios();
            ABMUsuarios.Show();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            frmAuditoria auditoria = new frmAuditoria();
            auditoria.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Se dispara el evento FormClosing y guarda la auditoría automáticamente
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void msCboTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSeleccionado = msCboTipoUsuario.SelectedItem.ToString();

            if (tipoSeleccionado == "Administrador")
            {
                btnABMUsuarios.Visible = true;
                btnGenerarReporte.Visible = true;
            }
            else
            {
                btnABMUsuarios.Visible = false;
                btnGenerarReporte.Visible = false;
            }
        }
        private void mostrarInfoUsuario()
        {
            // Usuario
            tslUsuario.Text = "👤 " + usuarioActual.NombreUsuario;

            // Fecha y desplazado a la derecha
            tslfecha.Text = "📅 " + DateTime.Now.ToString("dd/MM/yyyy");
            tslfecha.Alignment = ToolStripItemAlignment.Right;
        }
        // Este metodo me va permitir llenar el combobox y
        // activar en caso de que el tipousuario sea adm 
        // el boton ABM Usuario.
        private void CargarComboTipoUsuario()
        {
            msCboTipoUsuario.Items.Clear();

            if (usuarioActual.TipoUsuario == "Administrador")
            {
                msCboTipoUsuario.Items.Add("Administrador");
                msCboTipoUsuario.Items.Add("Usuario");
                msCboTipoUsuario.SelectedIndex = 0;
                btnABMUsuarios.Visible = true;
                cargarTareasUsuario();
            }
            else
            {
                msCboTipoUsuario.Items.Add("Usuario");
                msCboTipoUsuario.SelectedIndex = 0;
                msCboTipoUsuario.Enabled = false;
                btnABMUsuarios.Visible = false;
                cargarTareasUsuario();
            }
        }
        public void cargarTareasUsuario()
        {
            List<Tarea> tareas = TareaDatos.ObtenerTareasUsuario(usuarioActual.Id);
            dgvTareas.DataSource = tareas;

            AgregarColumnas();
        }
        private void AgregarColumnas()
        {
            if (dgvTareas.Columns.Contains("IdTarea"))
                dgvTareas.Columns["IdTarea"].HeaderText = "Código";

            if (dgvTareas.Columns.Contains("Titulo"))
                dgvTareas.Columns["Titulo"].HeaderText = "Título";

            if (dgvTareas.Columns.Contains("Descripcion"))
                dgvTareas.Columns["Descripcion"].HeaderText = "Descripción";

            if (dgvTareas.Columns.Contains("FechaVencimiento"))
                dgvTareas.Columns["FechaVencimiento"].HeaderText = "Vence el";

            if (dgvTareas.Columns.Contains("Prioridad"))
                dgvTareas.Columns["Prioridad"].HeaderText = "Prioridad";

            if (dgvTareas.Columns.Contains("Estado"))
                dgvTareas.Columns["Estado"].HeaderText = "Estado";

            if (dgvTareas.Columns.Contains("IdUsuario"))
                dgvTareas.Columns["IdUsuario"].Visible = false;

            dgvTareas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Este evento se dispara cuando se cierra el frmPrincipal
        // detiene el cronometro. Calcula el tiempo total usando .Elapsed
        // y registra la auditoria con el usuario que estaba logueado, su hora de ingreso y el tiempo total.
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cronometro.IsRunning)
            {
                cronometro.Stop();
            }

            TimeSpan tiempoUso = cronometro.Elapsed;

            AuditoriaDatos.RegistrarAuditoria(usuarioActual.Id, inicio, tiempoUso);
        }

        private void dgvTareas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTareas.CurrentRow != null)
            {
                Tarea tareaSeleccionada = (Tarea)dgvTareas.CurrentRow.DataBoundItem;
                frmModificarEliminar modificarEliminar = new frmModificarEliminar(tareaSeleccionada);
                modificarEliminar.ShowDialog();

                cargarTareasUsuario();
            }
        }

        private void btnRecargarDgv_Click(object sender, EventArgs e)
        {
            cargarTareasUsuario();
        }
    }
}
