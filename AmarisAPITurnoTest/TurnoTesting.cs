using AmarisAPITurno.BL;
using AmarisAPITurno.Controllers;
using AmarisAPITurno.DA;
using AmarisAPITurno.Interfaces;
using AmarisAPITurno.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AmarisAPITurnoTest
{
    public class TurnoTesting
    {
        private readonly TurnoController _turnoController;
        private readonly dbAmarisTurnosContext _dbAmarisTurnosContext;
        private readonly ITurnoBL _turnoBL;
        private readonly ITurnoDA _turnoDA;
        public TurnoTesting()//(TurnoController turnoController, dbAmarisTurnosContext dbAmarisTurnosContext)
        {
            _dbAmarisTurnosContext = new dbAmarisTurnosContext();
            _turnoDA = new TurnoDA(_dbAmarisTurnosContext);
            _turnoBL = new TurnoBL(_turnoDA);
            _turnoController = new TurnoController(_turnoBL);
        }
        [Fact]
        public async Task ObtenerTurnos_Ok()
        {
            // Arrange
            //var mockContext = new Mock<dbAmarisTurnosContext>();
            
            var resultado = await _turnoController.ObtenerTurnos();

            Assert.IsType<OkObjectResult>(resultado.ExecuteResultAsync);
        }
    }
}