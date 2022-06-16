using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Entidades.Extension;

namespace TestUnitarios
{
    [TestClass]
    public class AgregarListadoTest
    {
        [TestMethod]
        public void AgregarListado_CuandoRecibeUnaListaDePacientes_AgregaAListaPacientes()
        {
            //Arrange
            PacienteDAO pacienteDAO = new PacienteDAO();

            Paciente pacienteTest = new Paciente("Diego", "Gomez", "119-456-1265", "gomezd@gmail.com", 45789456, Paciente.EObraSocial.PASTEUR);

            List<Paciente> listaPaciente = new List<Paciente>() { pacienteTest };

            int cantidadPacientes = Clinica.ListadoPacientes.Count + 1;

            //Act
            listaPaciente.AgregarListado();                      

            //Assert            
            Assert.AreEqual(Clinica.ListadoPacientes.Count, cantidadPacientes);
            
            pacienteDAO.EliminarPorDNI(45789456);

        }

        [TestMethod]
        public void AgregarListado_CuandoRecibeUnaListaDeMedicos_AgregaAListaMedicos()
        {
            //Arrange
            MedicoDAO medicoDAO = new MedicoDAO();

            Medico medicoTest = new Medico("Mario", "Fernandez", "114-151-1417", "fernandezm@gmail.com", 25658987, Especialidad.Clínico);

            List<Medico> listaMedicos = new List<Medico>() { medicoTest };

            int cantidadMedicos = Clinica.ListadoMedicos.Count + 1;
            //Act
            listaMedicos.AgregarListado();

            //Assert
            Assert.AreEqual(Clinica.ListadoMedicos.Count, cantidadMedicos);           
            medicoDAO.EliminarPorDNI(25658987);

        }

        [TestMethod]
        public void AgregarListado_CuandoRecibeUnaListaDeTurnos_AgregaAListaTurnos()
        {
            //Arrange
            TurnoDAO turnoDAO = new TurnoDAO();
            MedicoDAO medicoDAO = new MedicoDAO();
            PacienteDAO pacienteDAO = new PacienteDAO();

            Medico medicoTest = new Medico("Mario", "Fernandez", "114-151-1417", "fernandezm@gmail.com", 25658987, Especialidad.Clínico);
            medicoDAO.Guardar(medicoTest);
            
            Paciente pacienteTest = new Paciente("Diego", "Gomez", "119-456-1265", "gomezd@gmail.com", 45789456, Paciente.EObraSocial.PASTEUR);
            pacienteDAO.Guardar(pacienteTest);
       
            DateTime fechaYHora = DateTime.Now.Date;
            Turno turnoTest = new Turno(fechaYHora, pacienteTest, medicoTest);
            List<Turno> listaTurnos = new List<Turno>() { turnoTest };

            int cantidadTurnos = Clinica.ListadoTurnos.Count + 1;
            //Act
            listaTurnos.AgregarListado();

            //Assert
            Assert.AreEqual(Clinica.ListadoTurnos.Count, cantidadTurnos);

            int idPaciente = pacienteTest.Id;
            turnoDAO.EliminarPorIdPaciente(idPaciente);
            medicoDAO.EliminarPorDNI(25658987);
            pacienteDAO.EliminarPorDNI(45789456);
        }

        
    }
}
