using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.Configuration
{
    public class LocalidadConfiguration : IEntityTypeConfiguration<Localidad>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Localidad> builder)
        {
            builder.ToTable("localidad");

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasKey(e => e.Nombre);
        }
    }
}