using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VP_Peliculas.Entidades
{
    public class Reclamos
    {
        public int Id { get; set; }
        public int Facturas { get; set; }
        public string? Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public string? Garantia { get; set; }
        public Facturas? Factura { get; set; }
    }
}
