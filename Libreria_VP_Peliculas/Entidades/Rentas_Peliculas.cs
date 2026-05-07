using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Rentas_Peliculas
    {
        public int Id { get; set; }
        public int Rentas { get; set; }
        public int Peliculas { get; set; }
        public int Formatos_Peliculas { get; set; }
        public int Cantidad { get; set; }
        public int Dias { get; set; }
        public decimal Precio_Dia { get; set; }
        public decimal Subtotal { get; set; } = 0.0m;
        public Rentas? Renta { get; set; }
        public Peliculas? Pelicula { get; set; }
        public Formatos_Peliculas? Formato_Pelicula { get; set; }
    }
}
