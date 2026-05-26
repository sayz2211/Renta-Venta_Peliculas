using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Libreria_VR_Peliculas.Entidades
{
    public class Usuarios
    {
        [Key] public int Id { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        public int? Roles { get; set; }
        [ForeignKey("Roles")] public Roles? _Rol { get; set; }

        [NotMapped] public List<Auditorias>? Auditorias { get; set; }
    }
}
