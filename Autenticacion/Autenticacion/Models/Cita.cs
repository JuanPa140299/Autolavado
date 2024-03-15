using System;
using System.Collections.Generic;

namespace Autenticacion.Models
{
    public partial class Cita
    {
        public int CitaId { get; set; }
        public string? ClienteId { get; set; }
        public DateTime? Fecha { get; set; }
        public int? ServicioId { get; set; }
        public string? Estado { get; set; }

        public virtual Servicio? Servicio { get; set; }
    }
}
