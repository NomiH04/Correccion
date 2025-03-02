using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Habitaciones
    {
        public Habitaciones(int numHabitacion, string tipoHabitacion, decimal precio, int capacidadMaxima, int duracionEstancia, string estado, string servicios, string imagenHabitacion)
        {
            this.habitacion = numHabitacion;
            this.tipoHabitacion = tipoHabitacion;
            this.precio = precio;
            this.capacidadMaxima = capacidadMaxima;
            this.duracionEstancia = duracionEstancia;
            this.estado = estado;
            this.servicios = servicios;
            this.imagenHabitacion = imagenHabitacion;
        }

        public int idHabitacion { get; set; }
        public int habitacion { get; set; }
        public string tipoHabitacion { get; set; }
        public decimal precio { get; set; }
        public int capacidadMaxima { get; set; }
        public int duracionEstancia { get; set; }
        public string estado { get; set; }
        public string servicios { get; set; }
        public string imagenHabitacion { get; set; }
    }
}
