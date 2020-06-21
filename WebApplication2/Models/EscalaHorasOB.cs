using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EscalaHorasOB
    {
        public int Id { get; set; }
        public float PorcentajeAumento { get; set; }

        public EscalaHorasOB(int id, float porcentaje)
        {
            this.Id = id;
            this.PorcentajeAumento = porcentaje;
        }
    }
}
