﻿using Microsoft.EntityFrameworkCore;
using RegistrosTecnico.Models;

namespace RegistrosTecnico.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Tecnicos> Tecnicos { get; set; }

    public DbSet<Clientes> Clientes { get; set; }

}
