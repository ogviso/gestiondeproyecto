﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Models;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication2.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("WebApplication2.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave");

                    b.Property<DateTime>("FechaIngreso");

                    b.Property<string>("Nombre");

                    b.Property<string>("Usuario");

                    b.HasKey("Id");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("WebApplication2.Models.EscalaAumentoxAntiguedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Limiteanios");

                    b.Property<float>("PorcentajeAumento");

                    b.HasKey("Id");

                    b.ToTable("EscalaAumentoxAntiguedad");
                });

            modelBuilder.Entity("WebApplication2.Models.EscalaAumentoxHora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("LimiteHoras");

                    b.Property<float>("PorcentajeAumento");

                    b.HasKey("Id");

                    b.ToTable("EscalaAumentoxHora");
                });

            modelBuilder.Entity("WebApplication2.Models.EscalaAumentoxPerfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LimitecantPerfiles");

                    b.Property<float>("PorcentajeAumento");

                    b.HasKey("Id");

                    b.ToTable("EscalaAumentoxPerfil");
                });

            modelBuilder.Entity("WebApplication2.Models.EscalaHorasOB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("PorcentajeAumento");

                    b.HasKey("Id");

                    b.ToTable("EscalaHorasOB");
                });

            modelBuilder.Entity("WebApplication2.Models.HorasTrabajadas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CantHoras");

                    b.Property<int>("EstadoHoras");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("IdProyecto");

                    b.Property<int>("IdTarea");

                    b.HasKey("Id");

                    b.ToTable("HorasTrabajadas");
                });

            modelBuilder.Entity("WebApplication2.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TipoPerfil");

                    b.Property<float>("ValorHorario");

                    b.HasKey("Id");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("WebApplication2.Models.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstadoProyecto");

                    b.Property<int>("IdCliente");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Proyecto");
                });

            modelBuilder.Entity("WebApplication2.Models.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("HorasEstimadas");

                    b.Property<float>("HorasOB");

                    b.Property<int>("IdEmpleado");

                    b.Property<int>("IdPerfil");

                    b.Property<int>("IdProyecto");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Tarea");
                });
#pragma warning restore 612, 618
        }
    }
}
