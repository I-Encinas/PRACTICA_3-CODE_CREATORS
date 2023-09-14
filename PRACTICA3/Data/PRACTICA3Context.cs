using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PRACTICA3.Modelos;

namespace PRACTICA3.Data
{
    public class PRACTICA3Context : DbContext
    {
        public PRACTICA3Context (DbContextOptions<PRACTICA3Context> options)
            : base(options)
        {
        }

        public DbSet<PRACTICA3.Modelos.Cliente>? Cliente { get; set; } 

        public DbSet<PRACTICA3.Modelos.Producto>? Producto { get; set; }

        public DbSet<PRACTICA3.Modelos.Venta>? Venta { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Venta>()
        //        .HasOne(v => v.Clientes)
        //        .WithMany()
        //        .HasForeignKey(v => v.IDCliente);

        //    modelBuilder.Entity<Venta>()
        //        .HasMany(v => v.Productos)
        //        .WithMany()
        //        .UsingEntity(j => j.ToTable("VENTAS_P"));
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Clientes)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.ClienteID);

            modelBuilder.Entity<Venta>()
                .HasMany(v => v.Productos)
                .WithMany(p => p.Ventas)
                .UsingEntity(j => j.ToTable("VENTAS_P"));
        }

    }
}
