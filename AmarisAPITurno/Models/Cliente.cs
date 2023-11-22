using System;
using System.Collections.Generic;

namespace AmarisAPITurno.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Turnos = new HashSet<Turno>();
        }

        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Identificacion { get; set; }

        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
