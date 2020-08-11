using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class TareaDto : IDto
    {
        public int ID { get; set; }
        public int IdProyecto { get; set; }
        public int IdEmpleado { get; set; }
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public float HorasEstimadas { get; set; }
        public float HorasOB { get; set; }
        private List<HorasTrabajadas> HorasTrabajadas = new List<HorasTrabajadas>();

    }
}
