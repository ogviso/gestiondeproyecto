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
        
        private List<Tarea> Tareas;

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

    }
}
