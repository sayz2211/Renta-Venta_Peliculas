using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Devoluciones
    {
        [Key] public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Multa { get; set; }
        public decimal Precio_Multa { get; set; }

        public int? Clientes { get; set; }
        public int? Peliculas { get; set; }
        public int? Facturas { get; set; }

        [ForeignKey("Clientes")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Peliculas")] public Peliculas? _Pelicula { get; set; }
        [ForeignKey("Facturas")] public Facturas? _Factura { get; set; }
    }
}
