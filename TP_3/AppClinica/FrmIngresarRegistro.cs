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
    public partial class FrmIngresarRegistro : Form
    {
        public FrmIngresarRegistro()
        {
            InitializeComponent();
        }

        private void FrmIngresarEstado_Load(object sender, EventArgs e)
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

        private void btnRegistrarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarEstados();

                if (MessageBox.Show("Registro exitoso", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }

            }
            catch (ListaVaciaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        /// <summary>
        /// Actualiza el Datagrid 
        /// </summary>
        private void ActualizarDataGrid()
        {
            dgPacientes.DataSource = Turno.FiltrarPorEstado(Turno.Estado.Pendiente);
            dgPacientes.Columns.Add(CrearComboBoxDeEstado());
            dgPacientes.Columns["EstadoTurno"].Visible = false;
          
        }

        
        /// <summary>
        /// Crea la columna del datagrid con combobox cargado con los estados 
        /// </summary>
        /// <returns>Columna con combobox</returns>
        private DataGridViewComboBoxColumn CrearComboBoxDeEstado()
        {
            DataGridViewComboBoxColumn comboboxPresentes = new DataGridViewComboBoxColumn();
            comboboxPresentes.ValueType = typeof(Turno.Estado);
            comboboxPresentes.DataSource = new Enum[] { Entidades.Turno.Estado.Espera, Entidades.Turno.Estado.Ausente };
            comboboxPresentes.DataPropertyName = "Estado";
            comboboxPresentes.Name = "Estado";
            return comboboxPresentes;
        }


        /// <summary>
        /// Cambia el estado del turno seun lo cargado en el combobox
        /// </summary>
        /// <exception cref="ListaVaciaException"></exception>
        private void CambiarEstados()
        {
            if (dgPacientes.Rows.Count == 0)
            {
                throw new ListaVaciaException("No hay turnos");
            }

            foreach (DataGridViewRow dg in dgPacientes.Rows)
            {
                if (dg.Cells["Estado"].Value != null)
                {
                    int auxId = int.Parse(dg.Cells["Id"].Value.ToString() ?? "");

                    foreach (Turno turno in Clinica.BuscarTurno(DateTime.Now.Date))
                    {
                        if (turno.Id == auxId)
                        {
                            turno.EstadoTurno = (Turno.Estado)dg.Cells["Estado"].Value;
                        }

                    }

                }
            }

        }

       





    }
}
