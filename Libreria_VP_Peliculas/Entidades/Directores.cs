using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Directores
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Premios { get; set; }
        public int CantidadP { get; set; }
        public List<Peliculas>? Peliculas { get; set; }
    }
}
