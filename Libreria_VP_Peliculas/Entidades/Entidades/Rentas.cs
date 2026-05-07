using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VP_Peliculas.Entidades
{
    public class Rentas
    {
        public int Id { get; set; }
        public decimal Precio_Dia { get; set; } = 0.0m;
        public int Cantidad { get; set; }
        public DateTime Fecha_Renta { get; set; }
        public DateTime Fecha_Limite { get; set; }
        public List<Rentas_Peliculas>? Rentas_Peliculas { get; set; }
        public List<Facturas>? Facturas { get; set; }
    }
}
