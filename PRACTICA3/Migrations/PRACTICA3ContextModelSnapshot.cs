﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PRACTICA3.Data;

#nullable disable

namespace PRACTICA3.Migrations
{
    [DbContext(typeof(PRACTICA3Context))]
    partial class PRACTICA3ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PRACTICA3.Modelos.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteID"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("CI")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("ClienteID");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PRACTICA3.Modelos.Producto", b =>
                {
                    b.Property<int>("ProductoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoID"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioU")
                        .HasColumnType("float");

                    b.HasKey("ProductoID");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("PRACTICA3.Modelos.Venta", b =>
                {
                    b.Property<int>("VentaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VentaID"), 1L, 1);

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("PrecioTotal")
                        .HasColumnType("float");

                    b.HasKey("VentaID");

                    b.HasIndex("ClienteID");

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("ProductoVenta", b =>
                {
                    b.Property<int>("ProductosProductoID")
                        .HasColumnType("int");

                    b.Property<int>("VentasVentaID")
                        .HasColumnType("int");

                    b.HasKey("ProductosProductoID", "VentasVentaID");

                    b.HasIndex("VentasVentaID");

                    b.ToTable("VENTAS_P", (string)null);
                });

            modelBuilder.Entity("PRACTICA3.Modelos.Venta", b =>
                {
                    b.HasOne("PRACTICA3.Modelos.Cliente", "Clientes")
                        .WithMany("Ventas")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("ProductoVenta", b =>
                {
                    b.HasOne("PRACTICA3.Modelos.Producto", null)
                        .WithMany()
                        .HasForeignKey("ProductosProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRACTICA3.Modelos.Venta", null)
                        .WithMany()
                        .HasForeignKey("VentasVentaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PRACTICA3.Modelos.Cliente", b =>
                {
                    b.Navigation("Ventas");
                });
#pragma warning restore 612, 618
        }
    }
}
