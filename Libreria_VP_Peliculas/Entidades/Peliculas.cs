using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Peliculas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Estreno { get; set; }
        public string? Clasi_edad { get; set; }
        public int puntuacion { get; set; }
        public bool Disponibilidad { get; set; }
        public int Directores { get; set; }
        public Directores? Director { get; set; }
        public List<TiposGeneros>? TiposGeneros { get; set; }
        public List<Repartos>? Repartos { get; set; }
        public List<Formatos_Peliculas>? Formatos_Peliculas { get; set; }
        public List<Inventarios>? Inventarios { get; set; }
        public List<Ventas_Peliculas>? Ventas_Peliculas { get; set; }
        public List<Rentas_Peliculas>? Rentas_Peliculas { get; set; }
    }
}
