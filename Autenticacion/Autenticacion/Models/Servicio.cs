using System;
using System.Collections.Generic;

namespace Autenticacion.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Cita = new HashSet<Cita>();
        }

        public int ServicioId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
