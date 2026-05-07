using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VP_Peliculas.Entidades
{
    public class Actores
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Nombre_Artistico { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Premios { get; set; }
        public int CantidadP { get; set; }

        public List<Repartos>? Repartos { get; set; }
    }
}
