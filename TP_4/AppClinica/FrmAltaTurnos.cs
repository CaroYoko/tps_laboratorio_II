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
    public partial class FrmAltaTurnos : Form
    {
        List<string> horarios = new List<string>() { "9:00", "9:15", "9:30", "9:45", "10:00", "10:15", "10:30", "10:45", "11:00", "11:15", "11:30", "11:45", "12:00", "12:15", "12:30", "12:45", "13:00", "13:15", "13:30", "13:45", "14:00", "14:15", "14:30", "14:45", "15:00" };

        public FrmAltaTurnos()
        {
            InitializeComponent();
        }

        private void FrmAltaTurnos_Load(object sender, EventArgs e)
        {
            cbEspecialidad.DataSource = Enum.GetValues(typeof(Especialidad));

            CargarComboboxMedico(Clinica.ListadoMedicos);
            CargarComboBoxPaciente();

            cbHorario.DataSource = horarios;
            cbHorario.SelectedIndex = -1;
            
            cbMedicos.SelectedIndex = -1;
            //cbEspecialidad.SelectedIndex = -1;

        }

        private void btnGenerarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                Medico medico = Medico.BuscarMedicoPorNombreYApellido(cbMedicos.Text);
                Paciente paciente = Paciente.BuscarPacientePorDNI(int.Parse(cbPacientes.Text));

                DateTime fecha = Convert.ToDateTime(dpFechaTurno.Text);
                if (cbHorario.SelectedItem is not null)
                {
                    DateTime hora = Convert.ToDateTime(cbHorario.SelectedItem);
                    DateTime fechaConvertida = fecha.AddHours(hora.Hour).AddMinutes(hora.Minute);
                    Turno turno = new Turno(fechaConvertida, paciente, medico);
                    turno.AgregarAListado();

                    if (MessageBox.Show("Agregado con éxito", "Turno", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else {
                    MessageBox.Show("Seleccionar horario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (NoDisponibleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NoEncontradoExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Los valores ingresados NO son válidos");
            }

        }

        private void cbHorario_Click(object sender, EventArgs e)
        {
            try {
                cbHorario.DataSource = CalcularHorarioDisponible();

            }
            catch (ErrorLecturaException ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Calcula el horario disponible del medico a partir del día elegido
        /// </summary>
        /// <returns>Lista de horarios disponibles</returns>
        private List<string> CalcularHorarioDisponible()
        {

            List<string> horaMinutosParaMedicosFecha = new List<string>();
            List<string> horarioDisponible = new List<string>();
            int auxDni;

            if (Clinica.ListadoTurnos.Count != 0 && int.TryParse(cbMedicos.Text, out auxDni))
            {
                foreach (Turno turno in Clinica.ListadoTurnos)
                {
                    if (!String.IsNullOrEmpty(cbMedicos.Text) && turno.Medico.Dni == auxDni
                        && turno.FechaYHora.Date == dpFechaTurno.Value.Date)
                    {
                        string horaMinutos = turno.FechaYHora.Hour + ":" + turno.FechaYHora.Minute.ToString().PadLeft(2, '0');
                        horaMinutosParaMedicosFecha.Add(horaMinutos);
                    }
                }

                foreach (string hora in horarios)
                {
                    if (!horaMinutosParaMedicosFecha.Contains(hora))
                    {
                        horarioDisponible.Add(hora);
                    }
                }
            }
            else
            {
                horarioDisponible = horarios;
            }

            return horarioDisponible;

        }

        /// <summary>
        /// Actualiza los comboBox con DNI de medicos según la especialidad elegida
        /// </summary>
        /// <returns>lista de medicos</returns>
        private List<Medico> ActualizarComboBoxMedicos()
        {                      
            return Medico.FiltrarMedicoPorEspecialidad((Especialidad)cbEspecialidad.SelectedItem);

        }

        /// <summary>
        /// Carga el comboBox de médicos segun la lista otorgada por parámetro 
        /// </summary>
        /// <param name="lista"></param>
        private void CargarComboboxMedico(List<Medico> lista)
        {
            cbMedicos.DataSource = lista;

        }
        
        /// <summary>
        /// Carga el comboBoc de pacientes con todos los pacientes de la lista
        /// </summary>
        private void CargarComboBoxPaciente()
        {
            AutoCompleteStringCollection stringColPaciente = new AutoCompleteStringCollection();
            foreach (Paciente paciente in Clinica.ListadoPacientes)
            {
                stringColPaciente.Add(paciente.Dni.ToString());
            }

            cbPacientes.AutoCompleteCustomSource = stringColPaciente;
            cbPacientes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbPacientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;                     


        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboboxMedico(ActualizarComboBoxMedicos());
        }        
                
        private void cbPacientes_Validated(object sender, EventArgs e)
        {
            int dniPaciente;
            if (cbPacientes is not null && int.TryParse(cbPacientes.Text, out dniPaciente))
            {
                txtPaciente.Text = Paciente.BuscarPacientePorDNI(dniPaciente).ToString();
            }

        }

        private void cbEspecialidad_Enter(object sender, EventArgs e)
        {
            CargarComboboxMedico(ActualizarComboBoxMedicos());

        }
    }
}
