using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Persistence.Data.Configuration;
public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Contrato> builder)
    {
        builder.ToTable("contrato");

        builder.Property(e => e.Monto)
        .HasPrecision(15,2)
        .IsRequired();

        builder.Property(e => e.Servicio)
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(e => e.FechaBaja)
        .HasColumnType("DATE")
        .IsRequired();
        builder.Property(e => e.FechaAlta)
        .HasColumnType("DATE")

        .IsRequired();
    }
}