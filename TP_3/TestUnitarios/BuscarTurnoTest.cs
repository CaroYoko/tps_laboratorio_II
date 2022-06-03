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
            Medico medicoTest = new Medico("Mario", "Fernandez", "11-1516-1417", "fernandezm@gmail.com", 25658987, Especialidad.Clínico);
            Paciente pacienteTest = new Paciente("Diego", "Gomez", "11-4567-1265", "gomezd@gmail.com", 45789456, Paciente.EObraSocial.PASTEUR);
            DateTime fechaYHora = DateTime.Now.Date;
            Turno turnoTest = new Turno(fechaYHora, pacienteTest, medicoTest);
            turnoTest.AgregarAListado();

            //Act
            List<Turno> actual = Clinica.BuscarTurno(fechaYHora, 45789456);

            //Assert

            Assert.AreEqual(actual.Count, 1);
            Assert.AreEqual(actual[0], turnoTest);



        }

        [TestMethod]
        public void BuscaTurno_CuandoHayFechaYDniEsCero_DevuelveListaFiltradaPorAmbosParametros()
        {
            //Arrange
            Medico medicoTest = new Medico("Mario", "Fernandez", "11-1516-1417", "fernandezm@gmail.com", 25658987, Especialidad.Clínico);
            Paciente pacienteTest = new Paciente("Diego", "Gomez", "11-4567-1265", "gomezd@gmail.com", 45789456, Paciente.EObraSocial.PASTEUR);
            DateTime fechaYHora = DateTime.Now.Date;
            Turno turnoTest = new Turno(fechaYHora, pacienteTest, medicoTest);
            turnoTest.AgregarAListado();
            
            List<Turno> actual = new List<Turno>();

            //Act
            actual = Clinica.BuscarTurno(fechaYHora, 0);

            //Assert
            Assert.AreEqual(actual.Count, 1);
            Assert.AreEqual(actual[0], turnoTest);

        }
    }
}
