using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        public Tipo TipoPerfil { get; set; }
        public float ValorHorario { get; set; }


        public enum Tipo
        {
            analista,
            desrrollador,
            tester,
            implementador,
            capacitador,
            supervisor
        }
    }
}
