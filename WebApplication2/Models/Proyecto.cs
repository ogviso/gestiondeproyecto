using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public Estado EstadoProyecto { get; set; }
        private List<HorasTrabajadas> Tareas = new List<HorasTrabajadas>();


        public enum Estado
        {
            Vigente,
            Finalizado,
            Pausado,
            Cancelado
        }

    }
}
