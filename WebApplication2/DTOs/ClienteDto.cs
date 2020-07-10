using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class ClienteDto : IDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        private List<Proyecto> Proyectos = new List<Proyecto>();

    }
}
