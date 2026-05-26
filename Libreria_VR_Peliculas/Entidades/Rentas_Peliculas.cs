using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Libreria_VR_Peliculas.Entidades
{
    public class Rentas_Peliculas
    {
        [Key] public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Dias { get; set; }
        public decimal Precio_Dia { get; set; }
        public decimal Subtotal { get; set; }

        public int? Rentas { get; set; }
        public int? Peliculas { get; set; }
        public int? Formatos_Peliculas { get; set; }
        [ForeignKey("Rentas")] public Rentas? _Renta { get; set; }
        [ForeignKey("Peliculas")] public Peliculas? _Pelicula { get; set; }
        [ForeignKey("Formatos_Peliculas")] public Formatos_Peliculas? _Formato_Pelicula { get; set; }
    }
}
