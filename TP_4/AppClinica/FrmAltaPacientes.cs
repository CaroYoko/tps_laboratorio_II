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
    public partial class FrmAltaPacientes : Form
    {
        PacienteDAO pacienteDAO;
        public FrmAltaPacientes()
        {
            InitializeComponent();
            pacienteDAO = new PacienteDAO();
            cbObraSocial.DataSource = Enum.GetValues(typeof(Paciente.EObraSocial));
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int auxDni;

                if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtApellido.Text) && !string.IsNullOrWhiteSpace(txtCelular.Text) && !string.IsNullOrWhiteSpace(txtEmail.Text) && !string.IsNullOrWhiteSpace(txtDni.Text) && int.TryParse(txtDni.Text, out auxDni))
                {

                    Paciente paciente = new Paciente(txtNombre.Text, txtApellido.Text, txtCelular.Text, txtEmail.Text, auxDni, (Paciente.EObraSocial)cbObraSocial.SelectedItem);
                    paciente.AgregarAListado();
                    pacienteDAO.Guardar(paciente);
                    this.Close();
                }
                else {

                    MessageBox.Show("Faltan campos por rellenar o son valores inválidos");
                    LimpiarTextBox();
                }

            }
            catch (ArgumentoNoValidoException ex)
            {
                MessageBox.Show(ex.Message);
                LimpiarTextBox();
            }
        }

        private void LimpiarTextBox() {
           
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtDni.Text = "";

        }
    }
}
