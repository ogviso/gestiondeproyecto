﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
  public class ApplicationDbContext : DbContext
  {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // El connectionString debe venir de un archivo de configuraciones!
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8PRIJ3M\SQLEXPRESS;Initial Catalog=GestionDeProyectosEfCore;Integrated Security=True")
            .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(new LoggerFactory().AddConsole((category, level) => level == LogLevel.Information && category == DbLoggerCategory.Database.Command.Name, true));
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<EscalaAumentoxAntiguedad> EscalaAumentoxAntiguedad { get; set; }
        public DbSet<EscalaAumentoxHora> EscalaAumentoxHora { get; set; }
        public DbSet<EscalaAumentoxPerfil> EscalaAumentoxPerfil { get; set; }
        public DbSet<EscalaHorasOB> EscalaHorasOB { get; set; }
        public DbSet<HorasTrabajadas> HorasTrabajadas { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Tarea> Tarea { get; set; }

    }



}
