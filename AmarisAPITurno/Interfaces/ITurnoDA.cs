using AmarisAPITurno.DTO;
using AmarisAPITurno.Models;

namespace AmarisAPITurno.Interfaces
{
    public interface ITurnoDA
    {
        public bool GuardarTurno(Turno turno);
        public List<Turno> ObtenerTurnos();
        public Turno ActivarTurno(int idTurno);
    }
}
