using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.Configuration;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Persona> builder)
    {
       builder.ToTable("persona");
        builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Correo)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(e => e.Usuario)
            .WithOne(e => e.Persona)
            .HasForeignKey<Usuario>(e => e.Id)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(e => e.Empleado)
            .WithOne(e => e.Persona)
            .HasForeignKey<Empleado>(e => e.Id)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}