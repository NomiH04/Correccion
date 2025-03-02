using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Reservaciones
    {
        public Reservaciones( int idHuesped, int idHabitacion, DateTime fechaCheckIn, DateTime fechaCheckOut,string estado, decimal montoTotal, string observaciones) 
        { 
            this.idHabitacion = idHabitacion;
            this.idHuesped = idHuesped;
            this.fechaCheckIn = fechaCheckIn;
            this.fechaCheckOut = fechaCheckOut;
            this.estadoReserva = estado;
            this.montoTotal = montoTotal;
            this.Observaciones = observaciones;
        }

        public int idReserva { get; set; }
        public int idHuesped { get; set; }
        public int idHabitacion { get; set; }
        public DateTime fechaCheckIn { get; set; }
        public DateTime fechaCheckOut { get; set; }
        public string estadoReserva { get; set; }
        public decimal montoTotal { get; set; }
        public string Observaciones { get; set; }
    }
}
