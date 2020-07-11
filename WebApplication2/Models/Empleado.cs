using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        private List<Tarea> Tareas =new List<Tarea>();
        public List<EmpleadoPerfil> EmpleadoPerfil = new List<EmpleadoPerfil>();

        public Empleado(int id, string nombre, DateTime FechaIng)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.FechaIngreso = FechaIng;
        }

        public void agregarTareas(Tarea tarea)
        {
            Tareas.Add(tarea);
        }

        public void eliminarTarea(int idTarea)
        {
            foreach (Tarea tarea in Tareas)
            {
                if (tarea.Id == idTarea)
                {
                    Tareas.Remove(tarea);
                }
            }
        }
        public List<Tarea> ObtenerTareas()
        {
            return Tareas;
        }
        public List<Tarea> ObtenerTareasPorProyecto(int idProyecto)
        {
            List<Tarea> tareasPorProyecto = new List<Tarea>();
            foreach (Tarea tarea in Tareas)
            {
                if (idProyecto == tarea.IdProyecto)
                {
                    tareasPorProyecto.Add(tarea);
                }
            }
            return tareasPorProyecto;
        }

        //Cantidad de horas trabajadoas por cada empleado en un periodo determinado por proyecto y por tipo de  perfil
        public float ObtenerHorasEmpleadoProyectoPerfil( DateTime fechadesde, DateTime fechahasta, int idProyecto, int idPerfil)
        {
            float horas = 0;
            List<Tarea> tareasPorProyecto = ObtenerTareasPorProyecto(idProyecto);
            foreach (Tarea tarea in tareasPorProyecto)
            {
                if(idPerfil == tarea.IdPerfil)
                {
                    foreach (HorasTrabajadas horasTrabajadas in tarea.ObtenerHorasTrabajadas())
                    {
                        if(horasTrabajadas.Fecha>= fechadesde && horasTrabajadas.Fecha <= fechahasta)
                        {
                            horas += horasTrabajadas.CantHoras;
                        }
                    }
                }
            }
            return horas;
        }
    }
}
