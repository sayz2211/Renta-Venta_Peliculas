
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Peliculas
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Estreno { get; set; }
        public string? Clasi_edad { get; set; }
        public int Puntuacion { get; set; }
        public bool Disponibilidad { get; set; }
        public string? ImagenNombre { get; set; }
        public int? Directores { get; set; }
        [ForeignKey("Directores")] public Directores? _Director { get; set; }

        [NotMapped] public List<TiposGeneros>? TiposGeneros { get; set; }
        [NotMapped] public List<Repartos>? Repartos { get; set; }
        [NotMapped] public List<Formatos_Peliculas>? Formatos_Peliculas { get; set; }
        [NotMapped] public List<Inventarios>? Inventarios { get; set; }
        [NotMapped] public List<Ventas_Peliculas>? Ventas_Peliculas { get; set; }
        [NotMapped] public List<Rentas_Peliculas>? Rentas_Peliculas { get; set; }
    }
}
