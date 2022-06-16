using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class BuscarTurnoTest
    {
        [TestMethod]
        public void BuscaTurno_CuandoHayFechaYDniDistintaDeCero_DevuelveListaFiltradaPorAmbosParametros()
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
            
            Turno turnoTest = new Turno(fechaYHora, Paciente.BuscarPacientePorDNI(45789456), Medico.BuscarMedicoPorNombreYApellido("Mario Fernandez"));
            
            turnoTest.AgregarAListado();            

            //Act
            List<Turno> actual = Clinica.BuscarTurno(fechaYHora, 45789456);

            //Assert
            Assert.AreEqual(actual.Count, 1);

            //Elimino lo creado
            turnoDAO.EliminarPorIdPaciente(pacienteTest.Id);
            medicoDAO.EliminarPorDNI(25658987);
            pacienteDAO.EliminarPorDNI(45789456);
        }

        [TestMethod]
        public void BuscaTurno_CuandoHayFechaYDniEsCero_DevuelveListaFiltradaPorAmbosParametros()
        {
            //Arrange
            TurnoDAO turnoDAO = new TurnoDAO();
            MedicoDAO medicoDAO = new MedicoDAO();
            PacienteDAO pacienteDAO = new PacienteDAO();            

            Medico medicoTest = new Medico("Mario", "Fernandez", "114-151-1417", "fernandezm@gmail.com", 25658987, Especialidad.Clínico);
            medicoDAO.Guardar(medicoTest);

            Paciente pacienteTest = new Paciente("Diego", "Gomez", "119-456-1265", "gomezd@gmail.com", 45789456, Paciente.EObraSocial.PASTEUR);       
            pacienteDAO.Guardar(pacienteTest);

            DateTime fechaYHora = new DateTime(2022, 06, 16);
            
            Turno turnoTest = new Turno(fechaYHora, Paciente.BuscarPacientePorDNI(45789456), Medico.BuscarMedicoPorNombreYApellido("Mario Fernandez"));

            turnoTest.AgregarAListado();

            //Act
            List<Turno> actual = Clinica.BuscarTurno(fechaYHora);


            //Assert
            Assert.AreEqual(actual.Count, 1);
            
            //Elimino lo creado
            turnoDAO.EliminarPorIdPaciente(pacienteTest.Id);
            medicoDAO.EliminarPorDNI(25658987);
            pacienteDAO.EliminarPorDNI(45789456);

        }
    }
}
