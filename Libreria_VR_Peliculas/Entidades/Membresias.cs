
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Libreria_VR_Peliculas.Entidades
{
    public class Membresias
    {
        [Key] public int Id { get; set; }
        public string? Tipo { get; set; }
        public decimal Precio { get; set; }
        public int DuracionDias { get; set; }
        public int RentasPermitidas { get; set; }
        public bool Activo { get; set; }

        [NotMapped] public List<Clientes>? Clientes { get; set; }
    }
}
