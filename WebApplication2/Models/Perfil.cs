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

        public Perfil(int id, Tipo tipo, float valor)
        {
            this.Id = id;
            this.TipoPerfil = tipo;
            this.ValorHorario = valor;
        }
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
