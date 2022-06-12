namespace AppClinica
{
    partial class FrmRecordatorio
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
            this.pbRecordatorio = new System.Windows.Forms.ProgressBar();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblRecordatorio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbRecordatorio
            // 
            this.pbRecordatorio.Location = new System.Drawing.Point(62, 105);
            this.pbRecordatorio.Name = "pbRecordatorio";
            this.pbRecordatorio.Size = new System.Drawing.Size(225, 27);
            this.pbRecordatorio.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(104, 179);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 31);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblRecordatorio
            // 
            this.lblRecordatorio.AutoSize = true;
            this.lblRecordatorio.Location = new System.Drawing.Point(104, 45);
            this.lblRecordatorio.Name = "lblRecordatorio";
            this.lblRecordatorio.Size = new System.Drawing.Size(141, 15);
            this.lblRecordatorio.TabIndex = 2;
            this.lblRecordatorio.Text = "Enviando recordatorios ...";
            // 
            // FrmRecordatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 267);
            this.Controls.Add(this.lblRecordatorio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pbRecordatorio);
            this.Name = "FrmRecordatorio";
            this.Text = "Recordatorios";
            this.Activated += new System.EventHandler(this.FrmRecordatorio_Activated);
            this.Load += new System.EventHandler(this.FrmRecordatorio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbRecordatorio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblRecordatorio;
    }
}