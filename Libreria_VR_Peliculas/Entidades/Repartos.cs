using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Repartos
    {
        [Key] public int Id { get; set; }
        public string? Personaje { get; set; }
        public string? Rol { get; set; }
        public int? Actores { get; set; }
        public int? Peliculas { get; set; }
        [ForeignKey("Actores")] public Actores? _Actor { get; set; }
        [ForeignKey("Peliculas")] public Peliculas? _Pelicula { get; set; }
    }
}
