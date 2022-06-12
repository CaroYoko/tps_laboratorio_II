namespace AppClinica
{
    partial class FrmListarTurnos
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
            this.dgTurnos = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.rbJson = new System.Windows.Forms.RadioButton();
            this.rbXml = new System.Windows.Forms.RadioButton();
            this.btnCancelarTurno = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTurnos
            // 
            this.dgTurnos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTurnos.Location = new System.Drawing.Point(34, 51);
            this.dgTurnos.Name = "dgTurnos";
            this.dgTurnos.RowTemplate.Height = 25;
            this.dgTurnos.Size = new System.Drawing.Size(617, 327);
            this.dgTurnos.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExportar.Location = new System.Drawing.Point(237, 12);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // rbJson
            // 
            this.rbJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbJson.AutoSize = true;
            this.rbJson.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbJson.Location = new System.Drawing.Point(78, 16);
            this.rbJson.Name = "rbJson";
            this.rbJson.Size = new System.Drawing.Size(51, 19);
            this.rbJson.TabIndex = 2;
            this.rbJson.TabStop = true;
            this.rbJson.Text = ".Json";
            this.rbJson.UseVisualStyleBackColor = true;
            // 
            // rbXml
            // 
            this.rbXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbXml.AutoSize = true;
            this.rbXml.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbXml.Location = new System.Drawing.Point(161, 16);
            this.rbXml.Name = "rbXml";
            this.rbXml.Size = new System.Drawing.Size(49, 19);
            this.rbXml.TabIndex = 3;
            this.rbXml.TabStop = true;
            this.rbXml.Text = ".Xml";
            this.rbXml.UseVisualStyleBackColor = true;
            // 
            // btnCancelarTurno
            // 
            this.btnCancelarTurno.Location = new System.Drawing.Point(275, 401);
            this.btnCancelarTurno.Name = "btnCancelarTurno";
            this.btnCancelarTurno.Size = new System.Drawing.Size(129, 23);
            this.btnCancelarTurno.TabIndex = 4;
            this.btnCancelarTurno.Text = "Cancelar Turno";
            this.btnCancelarTurno.UseVisualStyleBackColor = true;
            this.btnCancelarTurno.Click += new System.EventHandler(this.btnCancelarTurno_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImportar.Location = new System.Drawing.Point(381, 12);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(137, 23);
            this.btnImportar.TabIndex = 5;
            this.btnImportar.Text = "Importar desde Json";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // FrmListarTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 436);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnCancelarTurno);
            this.Controls.Add(this.rbXml);
            this.Controls.Add(this.rbJson);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgTurnos);
            this.Name = "FrmListarTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Turnos";
            this.Load += new System.EventHandler(this.FrmListarTurnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTurnos;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.RadioButton rbJson;
        private System.Windows.Forms.RadioButton rbXml;
        private System.Windows.Forms.Button btnCancelarTurno;
        private System.Windows.Forms.Button btnImportar;
    }
}