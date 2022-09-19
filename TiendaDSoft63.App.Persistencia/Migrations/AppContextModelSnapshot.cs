﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaDSoft63.App.Persistencia;

namespace TiendaDSoft63.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TiendaDSoft63.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Documentos")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Generos")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("TiendaDSoft63.App.Dominio.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("TiendaDSoft63.App.Dominio.Tienda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductosId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductosId");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("TiendaDSoft63.App.Dominio.Administrador", b =>
                {
                    b.HasBaseType("TiendaDSoft63.App.Dominio.Persona");

                    b.Property<DateTime>("FechaVinculación")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TiendasId")
                        .HasColumnType("int")
                        .HasColumnName("Administrador_TiendasId");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contrasenna")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("TiendasId");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("TiendaDSoft63.App.Dominio.Cliente", b =>
                {
                    b.HasBaseType("TiendaDSoft63.App.Dominio.Persona");

                    b.Property<DateTime>("FechaRegistroSistema")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductosId")
                        .HasColumnType("int");

                    b.Property<int?>("TiendasId")
                        .HasColumnType("int");

                    b.HasIndex("ProductosId");

                    b.HasIndex("TiendasId");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("TiendaDSoft63.App.Dominio.Vendedor", b =>
                {
                    b.HasBaseType("TiendaDSoft63.App.Dominio.Persona");

                    b.Property<int?>("ClientesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVinculaciónVendedor")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductosId")
                        .HasColumnType("int")
                        .HasColumnName("Vendedor_ProductosId");

                    b.Property<int?>("TiendaDSoftId")
                        .HasColumnType("int");

                    b.HasIndex("ClientesId");

                    b.HasIndex("ProductosId");

                    b.HasIndex("TiendaDSoftId");

                    b.HasDiscriminator().HasValue("Vendedor");
                });

            modelBuilder.Entity("TiendaDSoft63.App.Dominio.Tienda", b =>
                {
                    b.HasOne("TiendaDSoft63.App.Dominio.Producto", "Productos")
                        .WithMany()
                        .HasForeignKey("ProductosId");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("TiendaDSoft63.App.Dominio.Administrador", b =>
                {
                    b.HasOne("TiendaDSoft63.App.Dominio.Tienda", "Tiendas")
                        .WithMany()
                        .HasForeignKey("TiendasId");

                    b.Navigation("Tiendas");
                });

            modelBuilder.Entity("TiendaDSoft63.App.Dominio.Cliente", b =>
                {
                    b.HasOne("TiendaDSoft63.App.Dominio.Producto", "Productos")
                        .WithMany()
                        .HasForeignKey("ProductosId");

                    b.HasOne("TiendaDSoft63.App.Dominio.Tienda", "Tiendas")
                        .WithMany()
                        .HasForeignKey("TiendasId");

                    b.Navigation("Productos");

                    b.Navigation("Tiendas");
                });

            modelBuilder.Entity("TiendaDSoft63.App.Dominio.Vendedor", b =>
                {
                    b.HasOne("TiendaDSoft63.App.Dominio.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClientesId");

                    b.HasOne("TiendaDSoft63.App.Dominio.Producto", "Productos")
                        .WithMany()
                        .HasForeignKey("ProductosId");

                    b.HasOne("TiendaDSoft63.App.Dominio.Tienda", "TiendaDSoft")
                        .WithMany()
                        .HasForeignKey("TiendaDSoftId");

                    b.Navigation("Clientes");

                    b.Navigation("Productos");

                    b.Navigation("TiendaDSoft");
                });
#pragma warning restore 612, 618
        }
    }
}
