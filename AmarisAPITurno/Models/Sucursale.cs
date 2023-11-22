using System;
using System.Collections.Generic;

namespace AmarisAPITurno.Models
{
    public partial class Sucursale
    {
        public Sucursale()
        {
            Turnos = new HashSet<Turno>();
        }

        public int IdSucursal { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
