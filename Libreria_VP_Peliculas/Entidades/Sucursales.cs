using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Sucursales
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ciudad { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public List<Empleados>? Empleados { get; set; }
        public List<Inventarios>? Inventarios { get; set; }

    }
}
