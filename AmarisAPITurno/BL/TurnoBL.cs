using AmarisAPITurno.DTO;
using AmarisAPITurno.Interfaces;
using AmarisAPITurno.Models;
using System.Data;

namespace AmarisAPITurno.BL
{
    public class TurnoBL : ITurnoBL
    {
        public readonly ITurnoDA _turnoDA;
        public TurnoBL(ITurnoDA turnoDA) 
        {
            _turnoDA = turnoDA;
        }
        public async Task<Turno> GuardarTurno(TurnoDTO turno)
        {
            Turno crearTurno = new();
            try
            {
                crearTurno.FechaTurno = turno.FechaTurno;
                crearTurno.Codigo = turno.Codigo;
                crearTurno.Modulo = turno.Modulo;
                crearTurno.Activo = turno.Activo;
                crearTurno.IdCliente = turno.IdCliente;
                crearTurno.IdSucursal = turno.IdSucursal;
                _turnoDA.GuardarTurno(crearTurno);
                
                return await Task.FromResult(crearTurno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Turno>> ObtenerTurnos()
        {
            try
            {
                return await Task.FromResult(_turnoDA.ObtenerTurnos());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Turno> ActivarTurno(int idTurno)
        {
            return await Task.FromResult(_turnoDA.ActivarTurno(idTurno));
        }
    }
}
