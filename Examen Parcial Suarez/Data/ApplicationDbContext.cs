using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parcial_.Models;

namespace Parcial_.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Asignamiento> DbSetAsignamiento { get; set; }
    public DbSet<Jugadores> DbSetJugadores { get; set; }
    public DbSet<Equipos> DbSetEquipos { get; set; }

}
