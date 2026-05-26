
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Libreria_VR_Peliculas.Entidades
{
    public class Rentas
    {
        [Key] public int Id { get; set; }
        public decimal Precio_Dia { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha_Renta { get; set; }
        public DateTime Fecha_Limite { get; set; }

        [NotMapped] public List<Rentas_Peliculas>? Rentas_Peliculas { get; set; }
        [NotMapped] public List<Facturas>? Facturas { get; set; }
    }
}
