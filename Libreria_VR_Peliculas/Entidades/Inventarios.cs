
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Inventarios
    {
        [Key] public int Id { get; set; }
        public int Cantidad { get; set; }

        public int? Peliculas { get; set; }
        [ForeignKey("Peliculas")] public Peliculas? _Pelicula { get; set; }

        public int? Formatos { get; set; }
        [ForeignKey("Formatos")] public Formatos? _Formato { get; set; }

        public int? Sucursales { get; set; }
        [ForeignKey("Sucursales")] public Sucursales? _Sucursal { get; set; }

        public int? Proveedores { get; set; }
        [ForeignKey("Proveedores")] public Proveedores? _Proveedor { get; set; }
    }
}
