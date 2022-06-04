using System;
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
    public partial class FrmListarTurnos : Form
    {
        public FrmListarTurnos()
        {
            InitializeComponent();
        }

        private void FrmListarTurnos_Load(object sender, EventArgs e)
        {
            ActualizarDataGrid();
        }
                
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (ObtenerExtension() == ETipoExtension.Json)
            {            
                ArchivosJson<List<Turno>>.Escribir(Clinica.listadoTurnos, "Turnos",Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\");
            }
            else {
                ArchivosXml<List<Turno>>.Escribir(Clinica.listadoTurnos, "Turnos");
            }
                      
        }

        /// <summary>
        /// Actualiza el Datagrid
        /// </summary>
        private void ActualizarDataGrid()
        {
            dgTurnos.DataSource = Clinica.listadoTurnos;
        }

        /// <summary>
        /// Obtiene el tipo elegido con el radioButton
        /// </summary>
        /// <returns>.json o .xml</returns>
        private ETipoExtension ObtenerExtension()
        {
            if (rbJson.Checked)
            {
                return ETipoExtension.Json;
            }
            else
            {
                return ETipoExtension.Xml;
            }
        }
              
    }
}
