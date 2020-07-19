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
        public void BorrarPerfil(int idPerfil) { Perfil.Remove(GetPerfil(idPerfil));}

        public void ModificarCliente(Cliente cliente) { Cliente.Update(cliente); }
        public void ModificarEmpleado(Empleado empleado) { Empleado.Update(empleado); }
        public void ModificarProyecto(Proyecto proyecto) { Proyecto.Update(proyecto); }
        public void ModificarPerfil(Perfil perfil) { Perfil.Update(perfil); }

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

        public Perfil GetPerfil(int idPerfil)
        {
            Perfil p = null;
            foreach(Perfil perfil in Perfil)
            {
                if(perfil.Id == idPerfil)
                {
                    p=perfil;
                }
            }
            return p;
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
       
        public float liquidacion(int idEmpleado,DateTime fechadesde,DateTime fechahasta)
        {
            float costoLiquidacion = 0;
            //Obtengo la cantidad de horas trabajadas por tipo de perfil por empleado y la multipluco por el valor perfil
            Empleado emp = GetEmpleado(idEmpleado);
            float horasPerfil = 0;
            List<Tarea> tareasPorEMpleado = emp.ObtenerTareas();
            float HorasTotales = 0;
            int cantPerfiles =0;
            float HorasOB = 0;
            foreach (Perfil perfil in Perfil)
            {
                foreach (Tarea tarea in tareasPorEMpleado)
                {   //busco todas las tareas que coincidan con ese tipo de perfil y sumo las horas
                    if (perfil.Id == tarea.IdPerfil)
                    {
                        foreach (HorasTrabajadas horasTrabajadas in tarea.ObtenerHorasTrabajadas())
                        {
                            if (horasTrabajadas.Fecha >= fechadesde && horasTrabajadas.Fecha <= fechahasta && horasTrabajadas.EstadoHoras == Models.HorasTrabajadas.Estado.adeudadas)
                            {
                                horasPerfil += horasTrabajadas.CantHoras;
                                horasTrabajadas.EstadoHoras = Models.HorasTrabajadas.Estado.pagadas;
                            }
                        }
                        cantPerfiles++;
                        HorasOB += tarea.HorasOB;
                    }
                }
                //inicialmente el calculo es la suma de los productos de la cantidad  de horas con el valor perfil
                costoLiquidacion += horasPerfil * perfil.ValorHorario;
                //Las Horas Over Budge se pagan al 50%
                costoLiquidacion += HorasOB * perfil.ValorHorario * 50 / 100;
                HorasTotales += horasPerfil;
                horasPerfil = 0;
                HorasOB = 0;
            }

            //existe una escala en la que se indica un porcentaje de aumento x hora
            EscalaAumentoxHora.OrderBy(escalaHoras => escalaHoras.LimiteHoras);
            foreach (EscalaAumentoxHora aumentoxHoras in EscalaAumentoxHora)
            {
                if(aumentoxHoras.LimiteHoras >= HorasTotales)
                {
                    costoLiquidacion += costoLiquidacion * aumentoxHoras.PorcentajeAumento / 100;
                }
            }

            //si cumplio funciones en mas de un perfil tambien tendra un porcentaje de aumento
            EscalaAumentoxPerfil.OrderBy(escalaPerfil => escalaPerfil.LimitecantPerfiles);
            foreach (EscalaAumentoxPerfil aumentoxPerfil in EscalaAumentoxPerfil)
            {
                if (aumentoxPerfil.LimitecantPerfiles >= cantPerfiles)
                {
                    costoLiquidacion += costoLiquidacion * aumentoxPerfil.PorcentajeAumento / 100;
                }
            }

            return costoLiquidacion;
        }
        
    }
}
