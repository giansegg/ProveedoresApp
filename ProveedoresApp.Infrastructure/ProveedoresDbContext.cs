using Microsoft.EntityFrameworkCore;
using ProveedoresApp.Entity;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProveedoresApp.Infrastructure.Data
{
    public class ProveedoresDbContext : DbContext
    {
        public ProveedoresDbContext(DbContextOptions<ProveedoresDbContext> options)
            : base(options) { }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<User>Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.RazonSocial).IsRequired().HasMaxLength(100);
                entity.Property(p => p.NombreComercial).HasMaxLength(100);
                entity.HasIndex(p => p.IdentificacionTributaria).IsUnique();
                entity.Property(p => p.Telefono).HasMaxLength(20);
                entity.Property(p => p.Email).HasMaxLength(100);
                entity.Property(p => p.Website).HasMaxLength(100);
                entity.Property(p => p.Direccion).HasMaxLength(200);
                entity.Property(p => p.Pais).HasMaxLength(50);
                entity.Property(p => p.Facturacion).HasMaxLength(20);
                entity.Property(p => p.UltimaEdicion).IsRequired();
            });
            modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(u => u.Id);
                    entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                    entity.Property(u => u.PasswordHash).IsRequired().HasMaxLength(256);

                });
        }
    }
}
