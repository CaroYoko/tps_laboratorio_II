using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class AgregarListadoTest
    {
        [TestMethod]
        public void AgregarListado_CuandoRecibeUnaListaDePacientes_AgregaAListaPacientes()
        {
            //Arrange
            Clinica.ListadoPacientes.Clear();
            Paciente pacienteTest = new Paciente("Diego", "Gomez", "119-456-1265", "gomezd@gmail.com", 45789456, Paciente.EObraSocial.PASTEUR);
            List<Paciente> listaPaciente = new List<Paciente>() { pacienteTest };

            //Act
            Clinica.AgregarListado<Paciente>(listaPaciente);                      

            //Assert
            Assert.AreEqual(Clinica.ListadoPacientes.Count, 1);
            Assert.AreEqual(Clinica.ListadoPacientes[0], pacienteTest);

        }

        [TestMethod]
        public void AgregarListado_CuandoRecibeUnaListaDeMedicos_AgregaAListaMedicos()
        {
            //Arrange
            Clinica.ListadoMedicos.Clear();
            Medico medicoTest = new Medico("Mario", "Fernandez", "114-151-1417", "fernandezm@gmail.com", 25658987, Especialidad.Clínico);
            List<Medico> listaMedicos = new List<Medico>() { medicoTest };

            //Act
            Clinica.AgregarListado<Medico>(listaMedicos);

            //Assert
            Assert.AreEqual(Clinica.ListadoMedicos.Count, 1);
            Assert.AreEqual(Clinica.ListadoMedicos[0], medicoTest);

        }

        [TestMethod]
        public void AgregarListado_CuandoRecibeUnaListaDeTurnos_AgregaAListaTurnos()
        {

            //Arrange
            Clinica.ListadoTurnos.Clear();
            Medico medicoTest = new Medico("Mario", "Fernandez", "114-151-1417", "fernandezm@gmail.com", 25658987, Especialidad.Clínico);
            Paciente pacienteTest = new Paciente("Diego", "Gomez", "119-456-1265", "gomezd@gmail.com", 45789456, Paciente.EObraSocial.PASTEUR);
            DateTime fechaYHora = DateTime.Now.Date;
            Turno turnoTest = new Turno(fechaYHora, pacienteTest, medicoTest);
            List<Turno> listaMedicos = new List<Turno>() { turnoTest };

            //Act
            Clinica.AgregarListado<Turno>(listaMedicos);

            //Assert
            Assert.AreEqual(Clinica.ListadoTurnos.Count, 1);
            Assert.AreEqual(Clinica.ListadoTurnos[0], turnoTest);

        }

        
    }
}
