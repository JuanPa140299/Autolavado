using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Autenticacion.Models;
using System.Collections;

namespace Autenticacion.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Autenticacion.Models.Cita>? Cita { get; set; }
        public DbSet<Autenticacion.Models.Servicio>? Servicio { get; set; }
        public IEnumerable Servicios { get; internal set; }
    }
}