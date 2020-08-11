using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class ProyectoDto : IDto
    {
        public int ID { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string EstadoProyecto { get; set; }
        public ICollection<Tareadto> tareas { get; set; }

    }
}
