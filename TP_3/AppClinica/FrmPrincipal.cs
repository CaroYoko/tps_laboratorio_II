using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppClinica
{
    public partial class FrmPrincipal : Form
    {
        static bool primeraCargaPacientes;
        static bool primeraCargaMedicos;
        static bool primeraCargaTurnos;
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try {

                if (!primeraCargaPacientes)
                {
                    Clinica.Importar<Paciente>("Pacientes.json");
                    primeraCargaPacientes = true;
                }

                if (!primeraCargaMedicos)
                {
                    Clinica.Importar<Medico>("Medicos.json");
                    primeraCargaMedicos = true;
                }

                if (!primeraCargaTurnos)
                {
                    Clinica.Importar<Turno>("Turnos.json");
                    primeraCargaTurnos = true;
                }

                cbFiltrado.DataSource = Enum.GetValues(typeof(Turno.Estado));

                this.ActualizarDataGrid();
            }
            catch (NoEncontradoExcepcion ex) { 
            
                MessageBox.Show(ex.Message);

            }

        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltaPacientes frmAltaTurno = new FrmAltaPacientes();
            this.Visible = false;
            frmAltaTurno.ShowDialog();
            this.Visible = true;
        }

        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListarPacientes frmListarPacientes = new FrmListarPacientes();
            this.Visible = false;
            frmListarPacientes.ShowDialog();
            this.Visible = true;
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListarMedicos frmListarMedicos = new FrmListarMedicos();
            this.Visible = false;
            frmListarMedicos.ShowDialog();
            this.Visible = true;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltaTurnos frmAltaTurnos = new FrmAltaTurnos();
            this.Visible = false;
            frmAltaTurnos.ShowDialog();
            this.Visible = true;
        }

        private void verTodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmListarTurnos frmListarTurnos = new FrmListarTurnos();
            this.Visible = false;
            frmListarTurnos.ShowDialog();
            this.Visible = true;

        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarRegistro frmIngresarEstado = new FrmIngresarRegistro();
            this.Visible = false;
            frmIngresarEstado.ShowDialog();
            this.Visible = true;
            this.ActualizarDataGrid();
        }

        private void atenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarAtencion frmAtenderPaciente = new FrmIngresarAtencion();
            this.Visible = false;
            frmAtenderPaciente.ShowDialog();
            this.Visible = true;
            this.ActualizarDataGrid();
        }

        private void cbFiltrado_SelectedValueChanged(object sender, EventArgs e)
        {
            this.ActualizarDataGrid();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            ArchivosJson<List<Turno>>.Escribir(Clinica.listadoTurnos, "Turnos", AppDomain.CurrentDomain.BaseDirectory);
            ArchivosJson<List<Paciente>>.Escribir(Clinica.listadoPacientes, "Pacientes", AppDomain.CurrentDomain.BaseDirectory);

        }

        /// <summary>
        /// Actualiza el Datagrid
        /// </summary>
        public void ActualizarDataGrid()
        {
            dgTurnosHoy.DataSource = Clinica.BuscarTurno(DateTime.Now.Date);

            List<Turno> auxLista = new List<Turno>();

            switch ((Turno.Estado)cbFiltrado.SelectedItem)
            {
                case Turno.Estado.Ausente:
                    auxLista = Turno.FiltrarPorEstado(Turno.Estado.Ausente);
                    break;
                case Turno.Estado.Pendiente:
                    auxLista = Turno.FiltrarPorEstado(Turno.Estado.Pendiente);
                    break;
                case Turno.Estado.Atendido:
                    auxLista = Turno.FiltrarPorEstado(Turno.Estado.Atendido);
                    break;
                case Turno.Estado.Espera:
                    auxLista = Turno.FiltrarPorEstado(Turno.Estado.Espera);
                    break;
                case Turno.Estado.Todos:
                    auxLista = Turno.FiltrarPorEstado(Turno.Estado.Todos);
                    break;
            }

            dgTurnosHoy.DataSource = auxLista;

            dgTurnosHoy.Refresh();
        }

    }
}
