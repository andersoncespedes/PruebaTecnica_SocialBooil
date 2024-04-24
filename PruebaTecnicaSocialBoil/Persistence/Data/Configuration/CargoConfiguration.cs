using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.Configuration;
public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cargo> builder)
    {
        builder.ToTable("cargo");
        builder.Property(e => e.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(e => e.Descripcion)
        .IsRequired()
        .HasMaxLength(60);
    }
}