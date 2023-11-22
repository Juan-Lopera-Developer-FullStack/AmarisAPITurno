using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AmarisAPITurno.Models
{
    public partial class Turno
    {
        public int IdTurno { get; set; }
        public DateTime? FechaTurno { get; set; }
        public string? Codigo { get; set; }
        public short? Modulo { get; set; }
        public bool? Activo { get; set; }
        public int? IdCliente { get; set; }
        public int? IdSucursal { get; set; }
        [JsonIgnore]
        public virtual Cliente? oClientes { get; set; }
        [JsonIgnore]
        public virtual Sucursale? oSucursales { get; set; }
    }
}
