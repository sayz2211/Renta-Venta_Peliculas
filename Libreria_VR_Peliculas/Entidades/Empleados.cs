using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Empleados
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ciudad { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Cargo { get; set; }
        public int? Status { get; set; }
        public int? Sucursales { get; set; }

        [ForeignKey("Status")] public Status? _Status { get; set; }
        [ForeignKey("Sucursales")] public Sucursales? _Sucursal { get; set; }
    }
}
