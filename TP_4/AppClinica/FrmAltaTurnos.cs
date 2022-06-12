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

        }

        private void btnGenerarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                Medico medico = Medico.BuscarMedicoPorDNI(int.Parse(cbMedicos.Text));
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
            cbHorario.DataSource = CalcularHorarioDisponible();
        }

        private void cbMedicos_Click(object sender, EventArgs e)
        {
            CargarComboboxMedico(ActualizarComboBoxMedicos());
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
            List<Medico> auxLista = new List<Medico>();

            switch ((Especialidad)cbEspecialidad.SelectedItem)
            {
                case Especialidad.Clínico:
                    auxLista = Medico.FiltrarMedicoPorEspecialidad(Especialidad.Clínico);
                    break;
                case Especialidad.Nutrición:
                    auxLista = Medico.FiltrarMedicoPorEspecialidad(Especialidad.Nutrición);
                    break;
                case Especialidad.Pediatría:
                    auxLista = Medico.FiltrarMedicoPorEspecialidad(Especialidad.Pediatría);
                    break;
                case Especialidad.Cardiología:
                    auxLista = Medico.FiltrarMedicoPorEspecialidad(Especialidad.Cardiología);
                    break;
                case Especialidad.Neurología:
                    auxLista = Medico.FiltrarMedicoPorEspecialidad(Especialidad.Neurología);
                    break;
                case Especialidad.Gastroenterología:
                    auxLista = Medico.FiltrarMedicoPorEspecialidad(Especialidad.Gastroenterología);
                    break;
            }

            return auxLista;

        }

        /// <summary>
        /// Carga el comboBox de médicos segun la lista otorgada por parámetro 
        /// </summary>
        /// <param name="lista"></param>
        private void CargarComboboxMedico(List<Medico> lista)
        {
            AutoCompleteStringCollection stringColMedico = new AutoCompleteStringCollection();
            foreach (Medico medico in lista)
            {
                stringColMedico.Add(medico.Dni.ToString());
            }
            cbMedicos.AutoCompleteCustomSource = stringColMedico;
            cbMedicos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbMedicos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

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

        private void cbMedicos_Enter(object sender, EventArgs e)
        {
            CargarComboboxMedico(ActualizarComboBoxMedicos());
        }
    }
}
