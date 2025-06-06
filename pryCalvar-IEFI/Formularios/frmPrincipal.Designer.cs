namespace pryCalvar_IEFI
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslUsuario = new System.Windows.Forms.ToolStripLabel();
            this.tslfecha = new System.Windows.Forms.ToolStripLabel();
            this.dgvTareas = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminarTarea = new System.Windows.Forms.Button();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.btnModificarTarea = new System.Windows.Forms.Button();
            this.btnABMUsuarios = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.msCboTipoUsuario = new System.Windows.Forms.ToolStripComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslUsuario,
            this.tslfecha});
            this.toolStrip1.Location = new System.Drawing.Point(0, 366);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(692, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslUsuario
            // 
            this.tslUsuario.Name = "tslUsuario";
            this.tslUsuario.Size = new System.Drawing.Size(86, 22);
            this.tslUsuario.Text = "toolStripLabel1";
            // 
            // tslfecha
            // 
            this.tslfecha.Name = "tslfecha";
            this.tslfecha.Size = new System.Drawing.Size(86, 22);
            this.tslfecha.Text = "toolStripLabel2";
            this.tslfecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvTareas
            // 
            this.dgvTareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTareas.Location = new System.Drawing.Point(12, 30);
            this.dgvTareas.Name = "dgvTareas";
            this.dgvTareas.Size = new System.Drawing.Size(558, 324);
            this.dgvTareas.TabIndex = 19;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(576, 30);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(109, 37);
            this.btnAgregar.TabIndex = 23;
            this.btnAgregar.Text = "Agregar Tarea";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnEliminarTarea
            // 
            this.btnEliminarTarea.BackColor = System.Drawing.Color.Red;
            this.btnEliminarTarea.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminarTarea.Location = new System.Drawing.Point(576, 116);
            this.btnEliminarTarea.Name = "btnEliminarTarea";
            this.btnEliminarTarea.Size = new System.Drawing.Size(109, 37);
            this.btnEliminarTarea.TabIndex = 24;
            this.btnEliminarTarea.Text = "Eliminar Tarea";
            this.btnEliminarTarea.UseVisualStyleBackColor = false;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnGenerarReporte.ForeColor = System.Drawing.Color.White;
            this.btnGenerarReporte.Location = new System.Drawing.Point(576, 202);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(109, 37);
            this.btnGenerarReporte.TabIndex = 25;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = false;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // btnModificarTarea
            // 
            this.btnModificarTarea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnModificarTarea.ForeColor = System.Drawing.Color.White;
            this.btnModificarTarea.Location = new System.Drawing.Point(576, 73);
            this.btnModificarTarea.Name = "btnModificarTarea";
            this.btnModificarTarea.Size = new System.Drawing.Size(109, 37);
            this.btnModificarTarea.TabIndex = 26;
            this.btnModificarTarea.Text = "Modificar Tarea";
            this.btnModificarTarea.UseVisualStyleBackColor = false;
            // 
            // btnABMUsuarios
            // 
            this.btnABMUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnABMUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnABMUsuarios.Location = new System.Drawing.Point(576, 159);
            this.btnABMUsuarios.Name = "btnABMUsuarios";
            this.btnABMUsuarios.Size = new System.Drawing.Size(109, 37);
            this.btnABMUsuarios.TabIndex = 27;
            this.btnABMUsuarios.Text = "ABM Usuarios";
            this.btnABMUsuarios.UseVisualStyleBackColor = false;
            this.btnABMUsuarios.Click += new System.EventHandler(this.btnABMUsuarios_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.msCboTipoUsuario});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 27);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(52, 23);
            this.toolStripMenuItem1.Text = "Tareas";
            // 
            // msCboTipoUsuario
            // 
            this.msCboTipoUsuario.Name = "msCboTipoUsuario";
            this.msCboTipoUsuario.Size = new System.Drawing.Size(121, 23);
            this.msCboTipoUsuario.SelectedIndexChanged += new System.EventHandler(this.msCboTipoUsuario_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Orange;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(576, 317);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(109, 37);
            this.btnSalir.TabIndex = 29;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 391);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnABMUsuarios);
            this.Controls.Add(this.btnModificarTarea);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.btnEliminarTarea);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvTareas);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmPrincipal";
            this.Text = "Reporte";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslUsuario;
        private System.Windows.Forms.ToolStripLabel tslfecha;
        private System.Windows.Forms.DataGridView dgvTareas;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminarTarea;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Button btnModificarTarea;
        private System.Windows.Forms.Button btnABMUsuarios;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox msCboTipoUsuario;
        private System.Windows.Forms.Button btnSalir;
    }
}