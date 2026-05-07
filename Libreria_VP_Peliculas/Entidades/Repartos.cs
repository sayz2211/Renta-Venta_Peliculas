using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Repartos
    {
        public int Id { get; set; }
        public int Actores { get; set; }
        public int Peliculas { get; set; }
        public string? Personaje { get; set; }
        public string? Rol { get; set; }

        public Actores? Actor { get; set; }
        public Peliculas? Pelicula { get; set; }
    }
}
