using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Ventas
    {
        public int Id { get; set; }
        public decimal Precio_Venta { get; set; } = 0.0m;
        public int Cantidad { get; set; }

        public List<Ventas_Peliculas>? Ventas_Peliculas { get; set; }
        public List<Facturas>? Facturas { get; set; }
    }
}
