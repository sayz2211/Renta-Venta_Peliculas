using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Libreria_VR_Peliculas.Entidades
{
    public class TiposGeneros
    {
        [Key] public int Id { get; set; }
        public string? Genero { get; set; }

        public int? Peliculas { get; set; }
        [ForeignKey("Peliculas")] public Peliculas? _Pelicula { get; set; }
    }
}
