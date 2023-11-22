using AmarisAPITurno.DTO;
using AmarisAPITurno.Interfaces;
using AmarisAPITurno.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmarisAPITurno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        public readonly ITurnoBL _turnoBL;

        public TurnoController(ITurnoBL turnoBL)
        {
            _turnoBL = turnoBL; 
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearTurno([FromBody] TurnoDTO turno)
        {
            if (turno.IdCliente > 0 && turno.Codigo != null)
            {
                Turno respuesta = await _turnoBL.GuardarTurno(turno);
                return Ok(new { mensaje = "ok", response = respuesta });
            }
                return NoContent();
        }

        [HttpGet]
        [Route("ObtenerTurnos")]
        public async Task<IActionResult> ObtenerTurnos() => Ok(await _turnoBL.ObtenerTurnos());

        [HttpPatch("ActivarTurno/{idTurno}")]
        public async Task<IActionResult> ActivarTurno(int idTurno)
        {
            if (idTurno > 0)
            {
                var turno = await _turnoBL.ActivarTurno(idTurno);

                if(turno.Activo == true)
                {
                    return Ok(new { mensaje = "Turno activo" });
                }
                return Ok(new { mensaje = "Se supero los 15 minutos para activar turno" });
            }
            return BadRequest("El codigo no existe");
        }
    }
}
