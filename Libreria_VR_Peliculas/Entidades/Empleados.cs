using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Empleados : Personas
    {
        public string? Ciudad { get; set; }
        public string? Cargo { get; set; }
        public int? Status { get; set; }
        public int? Sucursales { get; set; }
        [ForeignKey("Status")] public Status? _Status { get; set; }
        [ForeignKey("Sucursales")] public Sucursales? _Sucursal { get; set; }
    }
}
