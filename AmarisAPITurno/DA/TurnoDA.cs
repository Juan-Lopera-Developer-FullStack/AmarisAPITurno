using AmarisAPITurno.DTO;
using AmarisAPITurno.Interfaces;
using AmarisAPITurno.Models;

namespace AmarisAPITurno.DA
{
    public class TurnoDA : ITurnoDA
    {
        public readonly dbAmarisTurnosContext _dbContext;

        public TurnoDA(dbAmarisTurnosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool GuardarTurno(Turno turno)
        {
            bool resultado;
            try
            {
                _dbContext.Turnos.Add(turno);
                _dbContext.SaveChanges();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Turno> ObtenerTurnos()
        {
            try
            {
                return _dbContext.Turnos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Turno ActivarTurno(int idTurno)
        {
            DateTime FechaActual = DateTime.Now;
            var turno = _dbContext.Turnos.Where(t => t.IdTurno == idTurno).FirstOrDefault();
            var limiteMinutos = FechaActual.AddMinutes(-15);
            if (limiteMinutos <= turno.FechaTurno)
            {
                turno.Activo = true;
                _dbContext.SaveChangesAsync();
                return turno;
            }
            return turno;
        }
    }
}
