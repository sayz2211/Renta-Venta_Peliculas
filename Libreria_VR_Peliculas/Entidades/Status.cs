using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Libreria_VR_Peliculas.Entidades
{
    public class Status
    {
        [Key] public int Id { get; set; }
        public bool Activo { get; set; }

        [NotMapped] public List<Clientes>? Clientes { get; set; }
        [NotMapped] public List<Empleados>? Empleados { get; set; }
    }
}
