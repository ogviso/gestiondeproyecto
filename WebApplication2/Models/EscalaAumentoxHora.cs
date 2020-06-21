using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EscalaAumentoxHora
    {
        public int Id { get; set; }
        public float LimiteHoras { get; set; }
        public float PorcentajeAumento { get; set; }

        public EscalaAumentoxHora(int id, float limite, float porcentaje)
        {
            this.Id = id;
            this.LimiteHoras = limite;
            this.PorcentajeAumento = porcentaje;
        }
    }
}
