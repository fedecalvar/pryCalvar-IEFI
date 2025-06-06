namespace pryCalvar_IEFI
{
    partial class frmAuditoria
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
            this.dgvAuditoria = new System.Windows.Forms.DataGridView();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAuditoria
            // 
            this.dgvAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoria.Location = new System.Drawing.Point(13, 13);
            this.dgvAuditoria.Name = "dgvAuditoria";
            this.dgvAuditoria.Size = new System.Drawing.Size(368, 236);
            this.dgvAuditoria.TabIndex = 0;
            // 
            // btnDescargar
            // 
            this.btnDescargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnDescargar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDescargar.Location = new System.Drawing.Point(387, 13);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(152, 41);
            this.btnDescargar.TabIndex = 17;
            this.btnDescargar.Text = "Descargar Auditoria";
            this.btnDescargar.UseVisualStyleBackColor = false;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(387, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 41);
            this.button1.TabIndex = 18;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 271);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDescargar);
            this.Controls.Add(this.dgvAuditoria);
            this.Name = "frmAuditoria";
            this.Text = "Auditoria";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAuditoria;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Button button1;
    }
}