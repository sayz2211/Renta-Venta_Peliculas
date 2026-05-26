using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Descuentos
    {
        [Key] public int Id { get; set; }
        public string? Descripcion { get; set; }
        public decimal Porcentaje { get; set; }
        public bool Activo { get; set; }

        [NotMapped] public List<Facturas>? Facturas { get; set; }
    }
}
