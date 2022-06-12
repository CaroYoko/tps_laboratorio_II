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
        static Turno? turnoSeleccion;

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
                ArchivosJson<List<Turno>>.Escribir(Clinica.ListadoTurnos, "Turnos_Exportado",Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\");
            }
            else {
                ArchivosXml<List<Turno>>.Escribir(Clinica.ListadoTurnos, "Turnos");
            }

            MessageBox.Show(String.Format($"Archivo exportado con éxito\n\nUbicación: {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Datos"), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
        }

        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            ObtenerFila();

            if (turnoSeleccion is not null && MessageBox.Show("¿Esta seguro de eliminar el turno?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes && Turno.BorrarTurno(turnoSeleccion))
            {
                dgTurnos.DataSource = null;
                ActualizarDataGrid();
            }
            else
            {
                MessageBox.Show("No ha seleccionado un cliente", "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Actualiza el Datagrid
        /// </summary>
        private void ActualizarDataGrid()
        {
            dgTurnos.DataSource = Clinica.ListadoTurnos;
            dgTurnos.Refresh();
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


        /// <summary>
        /// Obtiene el dato de la fila seleccionada del Datagrid
        /// </summary>
        private void ObtenerFila()
        {
            int indiceFila = dgTurnos.CurrentRow is not null ? dgTurnos.CurrentRow.Index : -1;

            if (indiceFila >= 0)
            {
                DataGridViewRow fila = dgTurnos.Rows[indiceFila];

                int auxId = int.Parse(fila.Cells["Id"].Value.ToString() ?? "");

                FrmListarTurnos.turnoSeleccion = Turno.BuscarTurnoPorId(auxId);
            }
            else
            {
                FrmListarTurnos.turnoSeleccion = null;
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            Clinica.Importar<Turno>("Turnos.json");
            ActualizarDataGrid();
        }
    }
}
