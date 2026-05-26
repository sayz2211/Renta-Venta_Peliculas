
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Libreria_VR_Peliculas.Entidades
{
    public class Facturas
    {
        [Key] public int Id { get; set; }
        public string? Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int? Clientes { get; set; }
        public int? Rentas { get; set; }
        public int? Ventas { get; set; }
        public int? Descuentos { get; set; }

        [ForeignKey("Clientes")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Rentas")] public Rentas? _Renta { get; set; }
        [ForeignKey("Ventas")] public Ventas? _Venta { get; set; }
        [ForeignKey("Descuentos")] public Descuentos? _Descuento { get; set; }
        [NotMapped] public List<Reclamos>? Reclamos { get; set; }
        [NotMapped] public List<Devoluciones>? Devoluciones { get; set; }
    }
}
