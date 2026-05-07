using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VP_Peliculas.Entidades
{
    public class Inventarios
    {
        public int Id { get; set; }

        public int Peliculas { get; set; }
        public int Cantidad { get; set; }
        public int Formatos { get; set; }
        public int Sucursales { get; set; }
        public Peliculas? Pelicula { get; set; }
        public Formatos? Formato { get; set; }
        public Sucursales? Sucursal { get; set; }
        public int Id_Proveedor { get; set; }
        public Proveedores? Proveedor { get; set; }
    }
}
