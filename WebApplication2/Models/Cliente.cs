using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        private List<Proyecto> Proyectos = new List<Proyecto>();
    }
}
