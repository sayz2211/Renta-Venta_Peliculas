using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class TiposGeneros
    {
        public int Id { get; set; }

        public string? Genero { get; set; }
        public Peliculas? Pelicula { get; set; }
    }
}
