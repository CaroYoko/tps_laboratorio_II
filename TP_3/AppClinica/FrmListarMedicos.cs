﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace AppClinica
{
    public partial class FrmListarMedicos : Form
    {        
        public FrmListarMedicos()
        {
            InitializeComponent();
        }

        private void FrmListarMedicos_Load(object sender, EventArgs e)
        {            
            this.ActualizarDataGrid();            
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ArchivosJson<List<Medico>>.Escribir(Clinica.listadoMedico, "Medicos_Exportado", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

        }

        /// <summary>
        /// Actualiza el Datagrid
        /// </summary>
        private void ActualizarDataGrid()
        {
            dgMedicos.DataSource = Clinica.listadoMedico;
            AjustarOrdenColumnas();
        }

        /// <summary>
        /// Ajusta el orden de las columnas del Datagrid
        /// </summary>
        private void AjustarOrdenColumnas()
        {
            dgMedicos.Columns["Id"].DisplayIndex = 0;
            dgMedicos.Columns["Especialidad"].DisplayIndex = 1;
            dgMedicos.Columns["Nombre"].DisplayIndex = 2;
            dgMedicos.Columns["Apellido"].DisplayIndex = 3;
            dgMedicos.Columns["Dni"].DisplayIndex = 4;
            dgMedicos.Columns["Celular"].DisplayIndex = 5;
            dgMedicos.Columns["Email"].DisplayIndex = 6;
        }
       

    }
}
