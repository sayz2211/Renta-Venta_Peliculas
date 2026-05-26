
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Proveedores
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Ciudad { get; set; }

        [NotMapped] public List<Inventarios>? Inventarios { get; set; }
    }
}
