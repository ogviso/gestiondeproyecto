using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        private List<Proyecto> Proyectos = new List<Proyecto>();
   
       
        public void agregarProyecto(Proyecto proyecto)
        {
            Proyectos.Add(proyecto);
        }

        public Proyecto GetProyecto(int idProyecto)
        {
            Proyecto p = null;
            foreach (Proyecto proyecto in Proyectos)
            {
                if (proyecto.Id == idProyecto)
                {
                    p = proyecto;
                }
            }
            return p;
        }

        public List<Proyecto> ObtenerProyectos()
        {
            return Proyectos;
        }

        public void eliminarProyecto(int idProyecto)
        {
            foreach (Proyecto proyecto in Proyectos)
            {
                if (proyecto.Id == idProyecto)
                {
                    Proyectos.Remove(proyecto);
                }
            }
        }
    }
}
