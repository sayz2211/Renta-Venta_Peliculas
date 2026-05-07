using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public int Clientes { get; set; }
        public int Rentas { get; set; }
        public int Ventas { get; set; }
        public int Descuentos { get; set; }
        public decimal Total { get; set; } = 0.0m;
        public Clientes? Cliente { get; set; }
        public Rentas? Renta { get; set; }
        public Ventas? Venta { get; set; }
        public List<Reclamos>? Reclamos { get; set; }
        public List<Devoluciones>? Devoluciones { get; set; }
    }
}
