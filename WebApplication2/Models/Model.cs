using Microsoft.EntityFrameworkCore;
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


        // Aca ponemos la configuracion que requiere cada entidad para EF cree las migraciones
        //#region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(b => b.Nombre)
                .IsRequired()
                .HasMaxLength(50);


            modelBuilder.Entity<Empleado>()
                .Property(b => b.Nombre)
                .IsRequired()
                .HasMaxLength(50);

        }
        //#endregion

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

        //--------------------------------Agregado por OMAR---------------------------------------

        public virtual void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                //intento interpretar el error
                    //throw TryDecodeDbUpdateException(dbEx);
                throw ;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //--------------------------------Agregado por Julian Manesi---------------------------------------
        public void AgregarClientes(Cliente cliente) { Cliente.Add(cliente); }
        public void AgregarEmpleados(Empleado empleado) { Empleado.Add(empleado); }
        public void AgregarProyectos(Proyecto proyecto) { Proyecto.Add(proyecto); }
        public Proyecto GetProyecto(int idProyecto)
        {
            Proyecto p = null;
            foreach (Proyecto proyecto in Proyecto)
            {
                if (proyecto.Id == idProyecto)
                {
                    p = proyecto;
                }
            }
            return p;
        }
        public Empleado GetEmpleado(int idEmpledo)
        {
            Empleado e = null;
            foreach (Empleado empleado in Empleado)
            {
                if (empleado.Id == idEmpledo)
                {
                    e = empleado;
                }
            }
            return e;
        }
        public Cliente GetCliente(int idCliente)
        {
            Cliente c = null;
            foreach (Cliente cliente in Cliente)
            {
                if (cliente.ID == idCliente)
                {
                    c = cliente;
                }
            }
            return c;
        }

        public List<Proyecto> ObtenerProyectosDeEmpleado(int idEmpleado)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            foreach (Proyecto proyecto in Proyecto)
            {
                foreach (Tarea tarea in proyecto.ObtenerTareas())
                {
                    if (tarea.IdEmpleado == idEmpleado && !proyectos.Contains(proyecto))
                        proyectos.Add(proyecto);
                }
            }
            return proyectos;
        }
    }

 
}
