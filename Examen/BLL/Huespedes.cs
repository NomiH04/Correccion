using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Huespedes
    {
        public Huespedes() { }
        public Huespedes(string nombreCompleto, DateTime fechaNacimiento, string genero, string telefono, string correoElectronico, string direccion, string fotoHuesped)
        {

            this.nombreCompleto = nombreCompleto;
            this.fechaNacimiento = fechaNacimiento;
            this.genero = genero;
            this.telefono = telefono;
            this.correoElectronico = correoElectronico;
            this.direccion = direccion;
            this.fotoHuesped = fotoHuesped; 
        }

        public Huespedes(int idHuesped , string nombreCompleto, DateTime fechaNacimiento, string genero, string telefono, string correoElectronico, string direccion, string fotoHuesped)
        {
            this.idHuesped = idHuesped;
            this.nombreCompleto = nombreCompleto;
            this.fechaNacimiento = fechaNacimiento;
            this.genero = genero;
            this.telefono = telefono;
            this.correoElectronico = correoElectronico;
            this.direccion = direccion;
            this.fotoHuesped = fotoHuesped;
        }

        public int idHuesped { get; set; }
        public string nombreCompleto { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string genero { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
        public string direccion { get; set; }
        public string fotoHuesped { get; set; }
    }
}
