using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VP_Peliculas.Entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public String? Correo { get; set; }
        public DateTime Fecha { get; set; }
        public string? Telefono { get; set; }
        public int Status { get; set; }
        public Status? estado { get; set; }
        public List<Facturas>? Facturas { get; set; }
        public List<Devoluciones>? Devoluciones { get; set; }
    }
}
