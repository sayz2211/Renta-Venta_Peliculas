using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Formatos
    {
        [Key] public int Id { get; set; }
        public string? Formato { get; set; }
        public string? Idioma { get; set; }
        public bool Subtitulada { get; set; }
        public bool Disponible { get; set; }

        [NotMapped] public List<Formatos_Peliculas>? Formatos_Peliculas { get; set; }
    }
}
