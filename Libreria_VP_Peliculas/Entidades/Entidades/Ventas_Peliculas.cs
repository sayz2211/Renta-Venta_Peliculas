using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VP_Peliculas.Entidades
{
    public class Ventas_Peliculas
    {
        public int Id { get; set; }
        public int Ventas { get; set; }
        public int Peliculas { get; set; }
        public int Formatos_Peliculas { get; set; }
        public decimal Precio_U { get; set; } = 0.0m;
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public Ventas? Venta { get; set; }
        public Peliculas? Pelicula { get; set; }
        public Formatos_Peliculas? Formato_Pelicula { get; set; }
    }
}
