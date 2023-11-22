using AmarisAPITurno.DTO;
using AmarisAPITurno.Models;

namespace AmarisAPITurno.Interfaces
{
    public interface ITurnoBL
    {
        public Task<Turno> GuardarTurno(TurnoDTO turno);
        public Task<List<Turno>> ObtenerTurnos();
        public Task<Turno> ActivarTurno(int idTurno);
    }
}
