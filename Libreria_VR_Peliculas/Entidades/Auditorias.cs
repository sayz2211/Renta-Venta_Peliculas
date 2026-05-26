using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Auditorias
    {
        [Key] public int Id { get; set; }
        public string? Tabla { get; set; }
        public string? Accion { get; set; }
        public DateTime Fecha { get; set; }
        public string? DatosAnteriores { get; set; }
        public string? DatosNuevos { get; set; }
        public int? Usuarios { get; set; }

        [ForeignKey("Usuarios")] public Usuarios? _Usuario { get; set; }
    }
}
