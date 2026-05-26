using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Libreria_VR_Peliculas.Entidades
{
    public class Reclamos
    {
        [Key] public int Id { get; set; }
        public string? Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public string? Garantia { get; set; }

        public int? Facturas { get; set; }
        [ForeignKey("Facturas")] public Facturas? _Factura { get; set; }
    }
}
