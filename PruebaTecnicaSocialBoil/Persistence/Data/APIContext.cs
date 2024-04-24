using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;
public class APIContext : DbContext
{
   
    public APIContext(DbContextOptions<APIContext> options) : base(options)
    {

    }
     public DbSet<Usuario> Usuarios  { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Contrato> Contratos    { get; set; }
    public DbSet<Departamento> Departamentos{ get; set; }
    public DbSet<Division> Divisiones { get; set; }
    public DbSet<Empleado> Empleados { get; set;}
    public DbSet<Localidad> Localidades { get; set; }
    public DbSet<Persona> Personas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}