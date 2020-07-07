using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EscalaAumentoxPerfil
    {
        public int Id { get; set; }
        public int LimitecantPerfiles { get; set; }
        public float PorcentajeAumento { get; set; }

        public EscalaAumentoxPerfil(int id, int limite, float porcentaje)
        {
            this.Id = id;
            this.LimitecantPerfiles = limite;
            this.PorcentajeAumento = porcentaje;
        }
    }
}
