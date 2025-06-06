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
            List<Auditoria> auditorias = AuditoriaDatos.ObtenerAuditoria();
            dgvAuditoria.DataSource = auditorias;

            if (dgvAuditoria.Columns.Contains("IdAuditoria"))
                dgvAuditoria.Columns["IdAuditoria"].Visible = false;

            if (dgvAuditoria.Columns.Contains("NombreUsuario"))
                dgvAuditoria.Columns["NombreUsuario"].HeaderText = "Usuario";

            if (dgvAuditoria.Columns.Contains("FechaRegistro"))
                dgvAuditoria.Columns["FechaRegistro"].HeaderText = "Fecha y hora de ingreso";

            if (dgvAuditoria.Columns.Contains("TiempoUso"))
                dgvAuditoria.Columns["TiempoUso"].HeaderText = "Tiempo de uso";

            dgvAuditoria.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dgvAuditoria.Columns["TiempoUso"].DefaultCellStyle.Format = @"hh\:mm\:ss";

            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            if (dgvAuditoria.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Guardar como";
            saveFileDialog.FileName = "Auditoria.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog.FileName))
                    {
                        // Escribe los encabezados, menos el idauditoria
                        bool primeraColumna = true;
                        foreach (DataGridViewColumn col in dgvAuditoria.Columns)
                        {
                            if (col.Name != "IdAuditoria")
                            {
                                if (!primeraColumna) sw.Write(";");
                                sw.Write(col.HeaderText);
                                primeraColumna = false;
                            }
                        }
                        sw.WriteLine();

                        // Escribe las filas
                        foreach (DataGridViewRow row in dgvAuditoria.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                primeraColumna = true;
                                foreach (DataGridViewColumn col in dgvAuditoria.Columns)
                                {
                                    if (col.Name != "IdAuditoria")
                                    {
                                        if (!primeraColumna) sw.Write(";");
                                        sw.Write(row.Cells[col.Index].Value?.ToString());
                                        primeraColumna = false;
                                    }
                                }
                                sw.WriteLine();
                            }
                        }
                    }

                    MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }
    }
}
