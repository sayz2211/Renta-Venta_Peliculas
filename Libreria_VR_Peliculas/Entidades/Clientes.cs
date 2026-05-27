using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Clientes : Personas
    {
        public string? Cedula { get; set; }
        public DateTime Fecha { get; set; }
        public int? Status { get; set; }
        public int? Membresias { get; set; }
        [ForeignKey("Status")] public Status? _Status { get; set; }
        [ForeignKey("Membresias")] public Membresias? _Membresia { get; set; }
        [NotMapped] public List<Facturas>? Facturas { get; set; }
        [NotMapped] public List<Devoluciones>? Devoluciones { get; set; }
    }
}
