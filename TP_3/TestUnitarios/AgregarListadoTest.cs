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
            Clinica.listadoPacientes.Clear();
            Paciente pacienteTest = new Paciente("Diego", "Gomez", "11-4567-1265", "gomezd@gmail.com", 45789456, Paciente.EObraSocial.PASTEUR);
            List<Paciente> listaPaciente = new List<Paciente>() { pacienteTest };

            //Act
            Clinica.AgregarListado<Paciente>(listaPaciente);                      

            //Assert
            Assert.AreEqual(Clinica.listadoPacientes.Count, 1);
            Assert.AreEqual(Clinica.listadoPacientes[0], pacienteTest);

        }

        [TestMethod]
        public void AgregarListado_CuandoRecibeUnaListaDeMedicos_AgregaAListaMedicos()
        {
            //Arrange
            Clinica.listadoMedico.Clear();
            Medico medicoTest = new Medico("Mario", "Fernandez", "11-1516-1417", "fernandezm@gmail.com", 25658987, Especialidad.Clínico);
            List<Medico> listaMedicos = new List<Medico>() { medicoTest };

            //Act
            Clinica.AgregarListado<Medico>(listaMedicos);

            //Assert
            Assert.AreEqual(Clinica.listadoMedico.Count, 1);
            Assert.AreEqual(Clinica.listadoMedico[0], medicoTest);

        }

        [TestMethod]
        public void AgregarListado_CuandoRecibeUnaListaDeTurnos_AgregaAListaTurnos()
        {

            //Arrange
            Clinica.listadoTurnos.Clear();
            Medico medicoTest = new Medico("Mario", "Fernandez", "11-1516-1417", "fernandezm@gmail.com", 25658987, Especialidad.Clínico);
            Paciente pacienteTest = new Paciente("Diego", "Gomez", "11-4567-1265", "gomezd@gmail.com", 45789456, Paciente.EObraSocial.PASTEUR);
            DateTime fechaYHora = DateTime.Now.Date;
            Turno turnoTest = new Turno(fechaYHora, pacienteTest, medicoTest);
            List<Turno> listaMedicos = new List<Turno>() { turnoTest };

            //Act
            Clinica.AgregarListado<Turno>(listaMedicos);

            //Assert
            Assert.AreEqual(Clinica.listadoTurnos.Count, 1);
            Assert.AreEqual(Clinica.listadoTurnos[0], turnoTest);

        }

        
    }
}
