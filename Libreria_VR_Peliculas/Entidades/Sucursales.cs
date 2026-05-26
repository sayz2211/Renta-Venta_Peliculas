using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Libreria_VR_Peliculas.Entidades
{
    public class Sucursales
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ciudad { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        [NotMapped] public List<Empleados>? Empleados { get; set; }
        [NotMapped] public List<Inventarios>? Inventarios { get; set; }
    }
}
