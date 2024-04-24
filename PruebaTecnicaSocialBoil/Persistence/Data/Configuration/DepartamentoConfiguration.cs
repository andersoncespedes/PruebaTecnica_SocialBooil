using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");

        builder.Property(e => e.NombreDivision)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.NombreDepartamento)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.NombreLocalidad)
        .HasMaxLength(50)
        .IsRequired();

        builder.HasOne(e => e.Division)
        .WithMany(e => e.Departamentos)
        .HasForeignKey(e => e.NombreDivision);

        builder.HasOne(e => e.Localidad)
        .WithMany(e => e.Departamentos)
        .HasForeignKey(e => e.NombreLocalidad);
    }
}