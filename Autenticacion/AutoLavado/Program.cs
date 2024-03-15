using Autenticacion.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura la cadena de conexión para la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agrega servicios de Identity
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Habilita la autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Configura el enrutamiento
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=H}/{action=Index}/{id?}");

// Ejecuta la aplicación
app.Run();