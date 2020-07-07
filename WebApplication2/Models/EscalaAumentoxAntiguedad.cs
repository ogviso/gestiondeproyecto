using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EscalaAumentoxAntiguedad
    {
        public int Id { get; set; }
        public int Limiteanios { get; set; }
        public float PorcentajeAumento { get; set; }
        public EscalaAumentoxAntiguedad(int id, int limite, float porcentaje)
        {
            this.Id = id;
            this.Limiteanios = limite;
            this.PorcentajeAumento = porcentaje;
        }
    }
}
