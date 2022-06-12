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
    public partial class FrmIngresarAtencion : Form
    {
        static Turno? turnoSeleccion;
        public FrmIngresarAtencion()
        {
            InitializeComponent();
        }

        private void FrmIngresarAtencion_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection listaAutocompletar = new AutoCompleteStringCollection();

            foreach (Turno turno in Clinica.BuscarTurno(DateTime.Now.Date))
            {
                listaAutocompletar.Add(turno.Paciente.Dni.ToString());
            }

            // configura el textBox del DNI del cliente
            this.txtDni.AutoCompleteCustomSource = listaAutocompletar;
            this.txtDni.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtDni.AutoCompleteSource = AutoCompleteSource.CustomSource;

            ActualizarDataGrid();

        }
               
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int dni;

            if (int.TryParse(txtDni.Text, out dni))
            {
                dgPacientes.DataSource = Clinica.BuscarTurno(DateTime.Now.Date, dni);
            }
            else
            {
                MessageBox.Show("El DNI ingresado es invalido");
            }

        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            try
            {
                CargarTurnoSeleccion();
                if (turnoSeleccion is not null)
                {
                    turnoSeleccion.EstadoTurno = Turno.Estado.Atendido;
                }

                if (MessageBox.Show("Atención exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }

            }
            catch (ListaVaciaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Actualiza el Datagrid
        /// </summary>
        private void ActualizarDataGrid()
        {
            dgPacientes.DataSource = Turno.FiltrarPorEstado(Turno.Estado.Espera);
        }

        /// <summary>
        /// Recupera el turno seleccionado en Datagrid
        /// </summary>
        /// <exception cref="ListaVaciaException"></exception>
        private void CargarTurnoSeleccion()
        {
            int indiceFila = dgPacientes.CurrentRow is not null ? dgPacientes.CurrentRow.Index : -1;

            if (dgPacientes.Rows.Count == 0)
            {
                throw new ListaVaciaException("No hay turnos");
            }

            if (indiceFila >= 0)
            {
                DataGridViewRow fila = dgPacientes.Rows[indiceFila];
                int auxId = int.Parse(fila.Cells["Id"].Value.ToString() ?? "");

                FrmIngresarAtencion.turnoSeleccion = Turno.BuscarTurnoPorId(auxId);
            }            

        }       
               
       
    }
}
