using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Formatos_Peliculas
    {
        [Key] public int Id { get; set; }
        public decimal Precio_Formato { get; set; }

        public int? Peliculas { get; set; }
        public int? Formatos { get; set; }
        public int? Inventarios { get; set; }
        [ForeignKey("Peliculas")] public Peliculas? _Pelicula { get; set; }
        [ForeignKey("Formatos")] public Formatos? _Formato { get; set; }
        [ForeignKey("Inventarios")] public Inventarios? _Inventario { get; set; }

        [NotMapped] public List<Ventas_Peliculas>? Ventas_Peliculas { get; set; }
        [NotMapped] public List<Rentas_Peliculas>? Rentas_Peliculas { get; set; }
    }
}
