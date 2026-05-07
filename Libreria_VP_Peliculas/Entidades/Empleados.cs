using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ciudad { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Cargo { get; set; }
        public int Status { get; set; }
        public Status? estado { get; set; }
        public Sucursales? Sucursal { get; set; }
    }
}
