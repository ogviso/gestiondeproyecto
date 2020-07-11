using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EmpleadoPerfil
    {
        public int IdEmpleado { get; set; }
        public int IdPerfil { get; set; }
        //public List<Tarea> Tareas = new List<Tarea>();

        public EmpleadoPerfil(int idEmpleado, int idPerfil)
        {
            IdEmpleado = idEmpleado;
            IdPerfil = idPerfil;
        }

    }
}
