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


        

        public void AgregarHorasTrabajadas(HorasTrabajadas horasT)
        {
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
