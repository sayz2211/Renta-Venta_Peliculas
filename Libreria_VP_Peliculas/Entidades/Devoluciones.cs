using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Devoluciones
    {
        public int Id { get; set; }
        public int Clientes { get; set; }
        public DateTime Fecha { get; set; }
        public int Peliculas { get; set; }
        public int Facturas { get; set; }
        public string? Multa { get; set; }
        public decimal Precio_Multa { get; set; } = 0.0m;
        public Clientes? Cliente { get; set; }
        public Peliculas? Pelicula { get; set; }
        public Facturas? Factura { get; set; }
    }
}
