using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Formatos_Peliculas
    {
        public int Id { get; set; }
        public int Peliculas { get; set; }
        public int Fomatos { get; set; }
        public int Invetarios { get; set; }
        public decimal Precio_Formato { get; set; } = 0.0m;
        public Peliculas? Pelicula { get; set; }
        public Formatos? Formato { get; set; }
        public Inventarios? Inventario { get; set; }
        public List<Ventas_Peliculas>? Ventas_Peliculas { get; set; }
        public List<Rentas_Peliculas>? Rentas_Peliculas { get; set; }
    }
}
