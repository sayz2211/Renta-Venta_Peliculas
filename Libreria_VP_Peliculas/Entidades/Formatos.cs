using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Formatos
    {
        public int Id { get; set; }
        public string? Formato { get; set; }
        public string? Idioma { get; set; }
        public bool Subtitulada { get; set; }
        public bool Disponible { get; set; }
        public List<Formatos_Peliculas>? Formatos_Peliculas { get; set; }
    }
}
