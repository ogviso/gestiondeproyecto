using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public int IdEmpleado { get; set; }
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public float HorasEstimadas { get; set; }
        public float HorasOB { get; set; }
        private List<HorasTrabajadas> HorasTrabajadas = new List<HorasTrabajadas>();


        public Tarea(int idProyecto, int idEmpleado, int idPerfil, int idTarea, string nombre, float horasEsti, float HorasOB)
        {
            this.IdProyecto = idProyecto;
            this.IdEmpleado = idEmpleado;
            this.IdPerfil = idPerfil;
            this.Id = idTarea;
            this.Nombre = nombre;
            this.HorasEstimadas = horasEsti;
            this.HorasOB = HorasOB;
        }

        public void AgregarHorasTrabajadas(HorasTrabajadas horasT)
        {
            //si un recurso carga más horas de las estimadas tiene que dar una alerta
            float HorasTrabajadasHastaAhora = 0;
            foreach (HorasTrabajadas horasTrabajadas in HorasTrabajadas)
            {
                HorasTrabajadasHastaAhora += horasTrabajadas.CantHoras;
            }
            /*horas trabajadas hasta ahora =16,horasT.CantHoras=8,HorasEstimadas=22
             entonces HorasOB=16+8-22=2
             cantHoras=8-2=6 osea las horas sobrantes las pongo como OB*/
            if (HorasTrabajadasHastaAhora + horasT.CantHoras> HorasEstimadas)
            {
                //Dar alerta
                HorasOB = HorasTrabajadasHastaAhora + horasT.CantHoras - HorasEstimadas;
                if (horasT.CantHoras - HorasOB > 0)
                    horasT.CantHoras = horasT.CantHoras - HorasOB;
                else
                    horasT.CantHoras = 0;
            }
            HorasTrabajadas.Add(horasT);
        }

        public List<HorasTrabajadas> ObtenerHorasTrabajadas()
        {
            return HorasTrabajadas;
        }

        public void eliminarHorasTrabajadas(int idHorasT)
        {
            foreach (HorasTrabajadas horas in HorasTrabajadas)
            {
                if (horas.Id == idHorasT)
                {
                    HorasTrabajadas.Remove(horas);
                }
            }
        }


    }
}
