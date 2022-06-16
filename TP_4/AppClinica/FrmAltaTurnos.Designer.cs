namespace AppClinica
{
    partial class FrmAltaTurnos
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
            this.btnGenerarTurno = new System.Windows.Forms.Button();
            this.dpFechaTurno = new System.Windows.Forms.DateTimePicker();
            this.cbPacientes = new System.Windows.Forms.ComboBox();
            this.lblDniPaciente = new System.Windows.Forms.Label();
            this.cbMedicos = new System.Windows.Forms.ComboBox();
            this.lblMedico = new System.Windows.Forms.Label();
            this.lblFechaTurno = new System.Windows.Forms.Label();
            this.cbHorario = new System.Windows.Forms.ComboBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGenerarTurno
            // 
            this.btnGenerarTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarTurno.Location = new System.Drawing.Point(104, 321);
            this.btnGenerarTurno.Name = "btnGenerarTurno";
            this.btnGenerarTurno.Size = new System.Drawing.Size(232, 45);
            this.btnGenerarTurno.TabIndex = 6;
            this.btnGenerarTurno.Text = "GENERAR TURNO";
            this.btnGenerarTurno.UseVisualStyleBackColor = true;
            this.btnGenerarTurno.Click += new System.EventHandler(this.btnGenerarTurno_Click);
            // 
            // dpFechaTurno
            // 
            this.dpFechaTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dpFechaTurno.CustomFormat = "dd/MM/yyyy";
            this.dpFechaTurno.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFechaTurno.Location = new System.Drawing.Point(149, 219);
            this.dpFechaTurno.Name = "dpFechaTurno";
            this.dpFechaTurno.Size = new System.Drawing.Size(245, 23);
            this.dpFechaTurno.TabIndex = 4;
            // 
            // cbPacientes
            // 
            this.cbPacientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPacientes.FormattingEnabled = true;
            this.cbPacientes.Location = new System.Drawing.Point(149, 31);
            this.cbPacientes.Name = "cbPacientes";
            this.cbPacientes.Size = new System.Drawing.Size(245, 23);
            this.cbPacientes.TabIndex = 1;
            this.cbPacientes.Validated += new System.EventHandler(this.cbPacientes_Validated);
            // 
            // lblDniPaciente
            // 
            this.lblDniPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDniPaciente.AutoSize = true;
            this.lblDniPaciente.Location = new System.Drawing.Point(53, 34);
            this.lblDniPaciente.Name = "lblDniPaciente";
            this.lblDniPaciente.Size = new System.Drawing.Size(81, 15);
            this.lblDniPaciente.TabIndex = 8;
            this.lblDniPaciente.Text = "D.N.I Paciente";
            // 
            // cbMedicos
            // 
            this.cbMedicos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMedicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMedicos.FormattingEnabled = true;
            this.cbMedicos.Location = new System.Drawing.Point(149, 172);
            this.cbMedicos.Name = "cbMedicos";
            this.cbMedicos.Size = new System.Drawing.Size(245, 23);
            this.cbMedicos.TabIndex = 3;
            // 
            // lblMedico
            // 
            this.lblMedico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMedico.AutoSize = true;
            this.lblMedico.Location = new System.Drawing.Point(87, 175);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(47, 15);
            this.lblMedico.TabIndex = 10;
            this.lblMedico.Text = "Médico";
            // 
            // lblFechaTurno
            // 
            this.lblFechaTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaTurno.AutoSize = true;
            this.lblFechaTurno.Location = new System.Drawing.Point(45, 222);
            this.lblFechaTurno.Name = "lblFechaTurno";
            this.lblFechaTurno.Size = new System.Drawing.Size(89, 15);
            this.lblFechaTurno.TabIndex = 11;
            this.lblFechaTurno.Text = "Fecha del turno";
            // 
            // cbHorario
            // 
            this.cbHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHorario.FormattingEnabled = true;
            this.cbHorario.ItemHeight = 15;
            this.cbHorario.Location = new System.Drawing.Point(149, 266);
            this.cbHorario.Name = "cbHorario";
            this.cbHorario.Size = new System.Drawing.Size(245, 23);
            this.cbHorario.TabIndex = 12;
            this.cbHorario.Click += new System.EventHandler(this.cbHorario_Click);
            // 
            // lblHora
            // 
            this.lblHora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(18, 269);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(116, 15);
            this.lblHora.TabIndex = 13;
            this.lblHora.Text = "Horarios Disponibles";
            // 
            // cbEspecialidad
            // 
            this.cbEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspecialidad.FormattingEnabled = true;
            this.cbEspecialidad.Location = new System.Drawing.Point(149, 125);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(245, 23);
            this.cbEspecialidad.TabIndex = 2;
            this.cbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cbEspecialidad_SelectedIndexChanged);
            this.cbEspecialidad.Enter += new System.EventHandler(this.cbEspecialidad_Enter);
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(62, 128);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(72, 15);
            this.lblEspecialidad.TabIndex = 15;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(82, 81);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(52, 15);
            this.lblPaciente.TabIndex = 16;
            this.lblPaciente.Text = "Paciente";
            // 
            // txtPaciente
            // 
            this.txtPaciente.Location = new System.Drawing.Point(149, 78);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(245, 23);
            this.txtPaciente.TabIndex = 17;
            // 
            // FrmAltaTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 389);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.cbEspecialidad);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.cbHorario);
            this.Controls.Add(this.lblFechaTurno);
            this.Controls.Add(this.lblMedico);
            this.Controls.Add(this.cbMedicos);
            this.Controls.Add(this.lblDniPaciente);
            this.Controls.Add(this.cbPacientes);
            this.Controls.Add(this.dpFechaTurno);
            this.Controls.Add(this.btnGenerarTurno);
            this.Name = "FrmAltaTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta Turnos";
            this.Load += new System.EventHandler(this.FrmAltaTurnos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerarTurno;
        private System.Windows.Forms.DateTimePicker dpFechaTurno;
        private System.Windows.Forms.ComboBox cbPacientes;
        private System.Windows.Forms.Label lblDniPaciente;
        private System.Windows.Forms.ComboBox cbMedicos;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.Label lblFechaTurno;
        private System.Windows.Forms.ComboBox cbHorario;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.ComboBox cbEspecialidad;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
    }
}