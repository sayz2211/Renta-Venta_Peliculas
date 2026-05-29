using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Libreria_VR_Peliculas.Entidades
{
    public class Ventas
    {
        [Key] public int Id { get; set; }
        public decimal Precio_Venta { get; set; }
        public int Cantidad { get; set; }
        public int? Clientes { get; set; }
        [ForeignKey("Clientes")] public Clientes? _Cliente { get; set; }
        [NotMapped] public List<Ventas_Peliculas>? Ventas_Peliculas { get; set; }
        [NotMapped] public List<Facturas>? Facturas { get; set; }
    }
}
