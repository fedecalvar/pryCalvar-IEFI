using pryCalvar_IEFI.Datos;
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
    public partial class frmAuditoria : Form
    {
        public frmAuditoria()
        {
            InitializeComponent();
            CargarAuditoria();
        }

        private void CargarAuditoria()
        {
            dgvAuditoria.DataSource = null;
            dgvAuditoria.DataSource = AuditoriaDatos.ObtenerAuditoria();

            dgvAuditoria.Columns["IdAuditoria"].Visible = false;

            dgvAuditoria.Columns["NombreUsuario"].HeaderText = "Usuario";
            dgvAuditoria.Columns["FechaRegistro"].HeaderText = "Fecha y hora de ingreso";
            dgvAuditoria.Columns["TiempoUso"].HeaderText = "Tiempo de uso";

            dgvAuditoria.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dgvAuditoria.Columns["TiempoUso"].DefaultCellStyle.Format = @"hh\:mm\:ss";
        }

    }
}
