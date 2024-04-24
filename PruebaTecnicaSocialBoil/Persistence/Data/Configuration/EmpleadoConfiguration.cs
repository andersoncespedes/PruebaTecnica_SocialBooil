
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entity;
namespace Persistence.Data.Configuration;
public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Salario)
        .HasPrecision(15,2)
        .IsRequired();

        builder.HasOne(e => e.Cargo)
        .WithMany(e => e.Empleados)
        .HasForeignKey(e => e.IdCargoFK);

    }
}