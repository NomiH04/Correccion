using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Habitaciones
    {
        public int idHabitacion { get; set; }
        public int habitacion { get; set; }
        public string tipoHabitacion { get; set; }
        public int precio { get; set; }
        public int capacidadMaxima { get; set; }
        public int duracionEstancia { get; set; }
        public string estado { get; set; }
        public string servicios { get; set; }
        public string imagenHabitacion { get; set; }
    }
}
