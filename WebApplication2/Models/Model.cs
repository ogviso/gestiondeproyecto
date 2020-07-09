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

        //--------------------------------Agregado por Julian Manesi---------------------------------------
       public void AgregarClientes(int id, string nombre) { Cliente.Add(new Cliente(id,nombre)); }
        public void AgregarEmpleados(int id,string nombre, DateTime FechaIng) { Empleado.Add(new Empleado(id, nombre,FechaIng)); }
        public void AgregarProyectos(int idCliente,int idProyecto,string nombre) { Proyecto.Add(new Proyecto(idCliente,idProyecto,nombre)); }
        public void AgregarPerfil(int id,Perfil.Tipo tipo,float valor) { Perfil.Add(new Perfil(id,tipo, valor)); }
        public void AgregarEscalaAumxAntiguedad(int id,int limite,float porcentaje) { EscalaAumentoxAntiguedad.Add(new EscalaAumentoxAntiguedad(id, limite, porcentaje)); }
        public void AgregarEscalaAumxhora(int id, int limite, float porcentaje) { EscalaAumentoxHora.Add(new EscalaAumentoxHora(id, limite, porcentaje)); }
        public void AgregarEscalaAumxPerfil(int id, int limite, float porcentaje) { EscalaAumentoxPerfil.Add(new EscalaAumentoxPerfil(id, limite, porcentaje)); }

        public void BorrarCliente( int idCliente) { Cliente.Remove(GetCliente(idCliente)); }  
        public void BorrarEmpleado(int idEmpleado) { Empleado.Remove(GetEmpleado(idEmpleado));}
        public void BorrarProyecto(int idProyecto) { Proyecto.Remove(GetProyecto(idProyecto));}

        public void ModificarCliente(Cliente cliente) { Cliente.Update(cliente); }
        public void ModificarEmpleado(Empleado empleado) { Empleado.Update(empleado); }
        public void ModificarProyecto(Proyecto proyecto) { Proyecto.Update(proyecto); }

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
                if (cliente.Id == idCliente)
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
