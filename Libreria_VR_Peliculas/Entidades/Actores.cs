using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Actores
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Nombre_Artistico { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Premios { get; set; }
        public int CantidadP { get; set; }

        [NotMapped] public List<Repartos>? Repartos { get; set; }
    }
}
