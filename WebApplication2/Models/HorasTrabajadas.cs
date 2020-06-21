using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class HorasTrabajadas
    {
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public int IdTarea { get; set; }
        public float CantHoras { get; set; }
        public DateTime Fecha { get; set; }
        public Estado EstadoHoras { get; set; }
        public HorasTrabajadas(int idProyecto, int idTarea, int idHoras, float cantHoras, DateTime fecha)
        {
            this.IdProyecto = idProyecto;
            this.IdTarea = idTarea;
            this.Id = idHoras;
            this.CantHoras = cantHoras;
            this.Fecha = fecha;
        }

        public enum Estado
        {
            pagadas,
            adeudadas
        }

    }
}
