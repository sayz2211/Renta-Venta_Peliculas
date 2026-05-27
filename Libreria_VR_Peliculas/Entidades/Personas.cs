using System.ComponentModel.DataAnnotations;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Personas
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
    }
}
