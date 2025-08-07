using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppFactura.Models;

public partial class DbFacturaContext : DbContext
{
    public DbFacturaContext()
    {
    }

    public DbFacturaContext(DbContextOptions<DbFacturaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Factura> Facturas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Factura>(entity =>
        {
            entity.ToTable("factura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Total).HasColumnName("total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
