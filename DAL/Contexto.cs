using Microsoft.EntityFrameworkCore;
using RegistrosTecnico.Models;

namespace RegistrosTecnico.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public virtual DbSet<Tecnicos> Tecnicos { get; set; }
    public virtual DbSet<Clientes> Clientes { get; set; }
    public virtual DbSet<Ciudades> Ciudades { get; set; }
    public virtual DbSet<Tickets> Tickets { get; set; }
    public virtual DbSet<Sistemas> Sistemas { get; set; }
    public virtual DbSet<Deudores> Deudores { get; set; }
    public virtual DbSet<Prestamos> Prestamos { get; set; }
    public virtual DbSet<Cobros> Cobros { get; set; }
    public virtual DbSet<CobrosDetalle> CobrosDetalle { get; set; }
    public virtual DbSet<PrestamosDetalle> PrestamosDetalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deudores>().HasData(
            new List<Deudores>()
            {
                new()
                {
                    DeudorId = 1,
                    Nombres = "Jose Lopez",
                },
                new()
                {
                    DeudorId = 2,
                    Nombres = "Maria Perez",
                }
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}
