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
    public partial class FrmListarPacientes : Form
    {
        static Paciente? pacienteSeleccion;
        PacienteDAO pacienteDAO;
        public FrmListarPacientes()
        {
            InitializeComponent();
            pacienteDAO = new PacienteDAO();
        }

        private void FrmListarPacientes_Load(object sender, EventArgs e)
        {          
            this.ActualizarDataGrid();
            this.ObtenerFila();

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                ArchivosJson<List<Paciente>>.Escribir(Clinica.ListadoPacientes, "Pacientes_Exportado", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\");
                MessageBox.Show(String.Format($"Archivo exportado con éxito\n\nUbicación: {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Datos"), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception) {

                MessageBox.Show("Error a exportar el archivo");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            ObtenerFila();

            if (pacienteSeleccion is not null && MessageBox.Show("¿Esta seguro de eliminar el paciente?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes && Paciente.BorrarPaciente(pacienteSeleccion))
            {                
                dgPacientes.DataSource = null;
                ActualizarDataGrid();
            }
            else {
                MessageBox.Show("No ha seleccionado un cliente", "Error", MessageBoxButtons.OK);
            }          

        }

        /// <summary>
        /// Actualiza el Datagrid
        /// </summary>
        private void ActualizarDataGrid()
        {            
            dgPacientes.DataSource = Clinica.ListadoPacientes;
            AjustarOrdenColumnas();

            dgPacientes.Refresh();

        }

        /// <summary>
        /// Ajusta el orden de las columnas del Datagrid
        /// </summary>
        private void AjustarOrdenColumnas()
        {
            dgPacientes.Columns["Id"].DisplayIndex = 0;
            dgPacientes.Columns["Nombre"].DisplayIndex = 1;
            dgPacientes.Columns["Apellido"].DisplayIndex = 2;
            dgPacientes.Columns["Dni"].DisplayIndex = 3;
            dgPacientes.Columns["ObraSocial"].DisplayIndex = 4;
            dgPacientes.Columns["Celular"].DisplayIndex = 5;
            dgPacientes.Columns["Email"].DisplayIndex = 4;
        }

        /// <summary>
        /// Obtiene el dato de la fila seleccionada del Datagrid
        /// </summary>
        private void ObtenerFila()
        {
            int indiceFila = dgPacientes.CurrentRow is not null ? dgPacientes.CurrentRow.Index : -1;

            if (indiceFila >= 0)
            {
                DataGridViewRow fila = dgPacientes.Rows[indiceFila];

                int auxId = int.Parse(fila.Cells["Id"].Value.ToString() ?? "");
               
                FrmListarPacientes.pacienteSeleccion = Paciente.BuscarPacientePorId(auxId);
            }
            else
            {
                FrmListarPacientes.pacienteSeleccion = null;
            }
        }

        
    }
}
