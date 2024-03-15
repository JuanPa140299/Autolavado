using System;
using System.Collections.Generic;

namespace Autenticacion.Models
{
    public partial class Vehiculo
    {
        public string Placa { get; set; } = null!;
        public string? Modelo { get; set; }
        public string? Marca { get; set; }
        public string? Color { get; set; }
        public string? IdCliente { get; set; }

        public virtual AspNetUsers? IdClienteNavigation { get; set; }
    }
}
