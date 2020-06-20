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


        public enum Estado
        {
            pagadas,
            adeudadas
        }

    }
}
