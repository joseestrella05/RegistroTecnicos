using Microsoft.EntityFrameworkCore;
using RegistrosTecnico.Models;

namespace RegistrosTecnico.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Tecnicos> Tecnicos { get; set; }

    public DbSet<Clientes> Clientes { get; set; }

    public DbSet<Ciudades> Ciudades { get; set; }

    public DbSet<Tickets> Tickets { get; set; }

    public DbSet<Sistemas> Sistemas { get; set; }
}
